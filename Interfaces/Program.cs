using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string productsFile = Path.Combine(Environment.CurrentDirectory, "products.txt");

            var internetStore = new InternetShop(new ProductHandler(new ProductStorage(new FileHandler(productsFile).Content).Objects),
                new ClientHandler(new Cli));
            internetStore.ViewStartMenu();
            #region example
            //MobileStore store = new MobileStore(
            //    new ConsolePhoneReader(), 
            //    new GeneralPhoneBinder(),
            //    new GeneralPhoneValidator(), 
            //    new TextPhoneSaver());
            //store.Process();
            //var menu = CreateMenu();
            //var userInputProcessor = new UserInputProcessor(menu);
            //userInputProcessor.Process();
            //Console.WriteLine(userInputProcessor.CurrentMenuItem.Description);
            //Console.ReadKey();
            //IShopHandler<IClient> clientHandler = new ClientHandler();
            //IShopHandler<IProduct> productHandler = new ProductHandler();
            #endregion
        }
        #region Menu


        //public static MenuItem CreateMenu()
        //{
        //    var MainMenu = new MenuItem("Main Menu", "m", "Main menu of programm", new List<MenuItem>
        //{
        //    new MenuItem("Product", "p", "Work with products: adding, editing", new List<MenuItem>
        //    {
        //        new MenuItem ("View products", "v", "View all products in the store", null, null),
        //        new MenuItem ("Edit product", "e", "Editing products", new List<MenuItem>
        //        {
        //            new MenuItem("Modify product", "m", "Modify existing product", null),
        //            new MenuItem("Add product", "a", "Add new product in the store", null)
        //        })
        //    }),
        //    new MenuItem("Client", "c", "Work with clients", new List<MenuItem>
        //    {
        //        new MenuItem ("View clients", "vc", "View all info about clients", null),
        //        new MenuItem ("Edit client", "ec", "Editing list clients", new List<MenuItem>
        //        {
        //            new MenuItem("Modify client info", "mc", "Modify existing client", null),
        //            new MenuItem("Add new client", "ac", "Add new client of store", null, new AddClient())
        //        })
        //    })
        //});
        //    return MainMenu;
        //}
        #endregion
    }
    #region Example Interface
    //class Phone
    //{
    //    public string Model { get; }
    //    public int Price { get; }
    //    public Phone(string model, int price)
    //    {
    //        Model = model;
    //        Price = price;
    //    }
    //}
    //class MobileStore
    //{
    //    List<Phone> phones = new List<Phone>();
    //    public IPhoneReader Reader { get; set; }
    //    public IPhoneBinder Binder { get; set; }
    //    public IPhoneValidator Validator { get; set; }
    //    public IPhoneSaver Saver { get; set; }
    //    public MobileStore(IPhoneReader reader, IPhoneBinder binder, IPhoneValidator validator, IPhoneSaver saver)
    //    {
    //        this.Reader = reader;
    //        this.Binder = binder;
    //        this.Validator = validator;
    //        this.Saver = saver;
    //    }
    //    public void Process()
    //    {
    //        string?[] data = Reader.GetInputData();
    //        Phone phone = Binder.CreatePhone(data);
    //        if (Validator.IsValid(phone))
    //        {
    //            phones.Add(phone);
    //            Saver.Save(phone, "store.txt");
    //            Console.WriteLine("Данные успешно обработаны");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Некорректные данные");
    //        }
    //    }
    //}
    //interface IPhoneReader
    //{
    //    string?[] GetInputData();
    //}
    //class ConsolePhoneReader : IPhoneReader
    //{
    //    public string?[] GetInputData()
    //    {
    //        Console.WriteLine("Введите модель:");
    //        string? model = Console.ReadLine();
    //        Console.WriteLine("Введите цену:");
    //        string? price = Console.ReadLine();
    //        return new string?[] { model, price };
    //    }
    //}
    //interface IPhoneBinder
    //{
    //    Phone CreatePhone(string?[] data);
    //}
    //class GeneralPhoneBinder : IPhoneBinder
    //{
    //    public Phone CreatePhone(string?[] data)
    //    {
    //        if (data is { Length: 2 } && data[0] is string model &&
    //            model.Length > 0 && int.TryParse(data[1], out var price))
    //        {
    //            return new Phone(model, price);

    //        }
    //        throw new Exception("Ошибка привязчика модели Phone. Некорректные данные");
    //    }
    //}
    //interface IPhoneValidator
    //{
    //    bool IsValid(Phone phone);
    //}
    //class GeneralPhoneValidator : IPhoneValidator
    //{
    //    public bool IsValid(Phone phone) =>
    //        !string.IsNullOrEmpty(phone.Model) && phone.Price > 0;
    //}
    //interface IPhoneSaver
    //{
    //    void Save(Phone phone, string fileName);
    //}
    //class TextPhoneSaver : IPhoneSaver
    //{
    //    public void Save(Phone phone, string fileName)
    //    {
    //        using StreamWriter writer = new StreamWriter(fileName, true);
    //        writer.WriteLine(phone.Model);
    //        writer.WriteLine(phone.Price);
    //    }
    //}
    #endregion
}
