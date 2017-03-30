using aspnet_mvc5_sample.Repositories;
using aspnet_mvc5_sample.Repositories.Abstractions;
using aspnet_mvc5_sample.Services.Abstractions;
using aspnet_mvc5_sample.ViewModels.ToDo;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using TuesPechkin;

namespace aspnet_mvc5_sample.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IItemRepository _itemRepository;
        public ReportService() : this(new ItemRepository())
        {

        }
        public ReportService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ToDoListViewModel GetAll()
        {
            var data = _itemRepository.GetAll();

            var todoList = new List<ItemViewModel>();
            foreach (var item in data)
            {
                var todo = new ItemViewModel();
                todo.SetFromModel(item);
                todoList.Add(todo);
            }

            var model = new ToDoListViewModel();
            model.ToDoList = todoList;
            return model;
        }

        public byte[] Create(string indexUrl)
        {
            var document = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = "PDF Sample",
                    PaperSize = PaperKind.A3,
                    Margins =
                    {
                        All = 1.375,
                        Unit = Unit.Centimeters
                    }
                },
                Objects =
                    {
                        new ObjectSettings()
                        {
                            PageUrl = indexUrl,
                        },
                    }
            };

            var converter = new StandardConverter(
                new PdfToolset(
                    new WinAnyCPUEmbeddedDeployment(
                        new TempFolderDeployment())));
            var pdfData = converter.Convert(document);

            return pdfData;
        }
    }
}