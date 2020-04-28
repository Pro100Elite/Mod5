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

        public IEnumerable<ArticleModel> GetArticles()
        {
            var articles = _mapper.Map<IEnumerable<ArticleModel>>(_repository.GetArticles());

            return articles;
        }

        public IEnumerable<ArticleModel> GetArticlesForAuthor(int author)
        {
            var articles = _mapper.Map<IEnumerable<ArticleModel>>(_repository.GetArticles().Where(x => x.Author.Id == author));

            return articles;
        }

        public ArticleModel GetById(int id)
        {
            var article = _mapper.Map<ArticleModel>(_repository.GetById(id));

            return article;
        }

        public ArticleModel GetForRead(int id, int pagenumber)
        {
            var article = _mapper.Map<ArticleModel>(_repository.GetById(id));

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(article.Book);
            //Exporting specify page index as image
            if (pagenumber >= 0 & pagenumber < loadedDocument.Pages.Count)
            {
                Bitmap image = loadedDocument.ExportAsImage(pagenumber);

                //Save the image as JPG format
                string path = "I:/project/Mod5/PortalForReading/PortalForReading/Resourses/result.jpg";
                image.Save(path, ImageFormat.Jpeg);

                article.Book = "~/Resourses/result.jpg";

                //Close the document
                loadedDocument.Close(true);
            }

            return article;
        }

        public void EditArticle(ArticleModel articleModel)
        {
            var article = _mapper.Map<Article>(articleModel);

            _repository.Update(article);
        }
    }
}
