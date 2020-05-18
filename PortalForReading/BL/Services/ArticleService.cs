using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _repository = articleRepository;
            _mapper = mapper;
        }

        public IEnumerable<ArticleModel> GetArticles(int? category)
        {
            IEnumerable<Article> articles;

            if (category != null) 
            {
                articles = _repository.GetArticles(category);
            }
            else
            {
                articles = _repository.GetArticles();
            }

            var result = _mapper.Map<IEnumerable<ArticleModel>>(articles);

            return result;
        }

        public IEnumerable<ArticleModel> GetByAuthor(int author)
        {
            var articles = _repository.GetByAuthor(author);
            var result = _mapper.Map<IEnumerable<ArticleModel>>(articles);

            return result;
        }

        public ArticleModel GetById(int id)
        {
            var article = _repository.GetById(id);
            var result = _mapper.Map<ArticleModel>(article);

            return result;
        }

        public IEnumerable<ArticleModel> Filter(string filter)
        {
            var articles = _repository.Filter(filter);
            var result = _mapper.Map<IEnumerable<ArticleModel>>(articles);

            return result;
        }

        public ArticleModel GetForRead(int id, int pagenumber)
        {
            var article = _repository.GetById(id);
            var result = _mapper.Map<ArticleModel>(article);

            string localPath = AppDomain.CurrentDomain.BaseDirectory;

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument($"{localPath}{result.Book}");
            //Exporting specify page index as image
            if (pagenumber >= 0 & pagenumber < loadedDocument.Pages.Count)
            {
                Bitmap image = loadedDocument.ExportAsImage(pagenumber);

                //Save the image as JPG format
                string path = $"{localPath}Resourses/result.jpg";
                image.Save(path, ImageFormat.Jpeg);

                result.Book = "~/Resourses/result.jpg";

                //Close the document
                loadedDocument.Close(true);
            }

            return result;
        }

        public void Create(ArticleModel articleModel)
        {
            var article = _mapper.Map<Article>(articleModel);

            _repository.Create(article);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Edite(ArticleModel articleModel)
        {
            var article = _mapper.Map<Article>(articleModel);

            _repository.Update(article);
        }

        public Dictionary<int, string> GetArticleToDelete()
        {
            return _repository.GetArticles().ToDictionary(x => x.Id, x => x.Title);
        }
    }
}
