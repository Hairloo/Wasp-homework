using System.Collections.ObjectModel;

namespace Lesson_1;

public class MusicDisk
{
    public static void Main(string[] args)
    {
        Store newStore = new Store("Rock you", "Vernandka 78");
        Audio a1 = new Audio("AlexDarkStalker98", "Gufovskiy", 2228, "Lirycs", "Melodrama");
        Audio a2 = new Audio("Krovostok", "ShiloStudios", 64, "Babochki", "Stihi");
        DVD d1 = new DVD("Rich Gay", "Rich Gay Studios", 1213, "The Snitch", "Neozhidannye povoroty");
        DVD d2 = new DVD("Khto Ya", "Khto Ty", 654, "1+1", "Comedy");
        Collection<Audio> col1 = new Collection<Audio>();
        Collection<DVD> col2 = new Collection<DVD>();
        //d1.Burn("Che", "Proishodit", "11111"); //прожигание диска до добавления в коллецию(просто запись после добавления не повлияет на вывод данных на экран(кроме размера диска))
        col1 = newStore.addAudio(a1);
        col1 = newStore.addAudio(a2);
        col2 = newStore.addDVD(d1);
        col2 = newStore.addDVD(d2);
        Console.WriteLine(newStore);
        d1.Burn("Che", "Proishodit", "11111");//прожигание после добавления в коллекцию(в тз этот пункт стоит после добавления в коллекцию, поэтому я в недоумении как изначально задумывалось) 
        foreach (var audio in col1)
        {
            Console.WriteLine($"Name: {audio.name} -> disk size: {audio.DiskSize}");
        }

        foreach (var dvd in col2)
        {
            Console.WriteLine($"Name: {dvd.name} -> disk size: {dvd.DiskSize}");
        }
    }
}

internal interface IStoreItem
{
    double Price
    {
        set => Price = Price;
        get => Price;
    }

    public void DiscountPrice(int percent)
    {
        Price -= Price * percent / 100;
    }
}

internal class Disk : IStoreItem
{
    private string Name, Genre;
    public string name
    {
        get => Name;
    }

    protected string genre
    {
        get => Genre;
    }

    protected int burnCount { get; set; }

    public Disk(string Name, string Genre)
    {
        this.Name = Name;
        this.Genre = Genre;
    }

    public virtual int DiskSize
    {
        get => DiskSize;
    }

    public virtual void Burn(params string[] values)
    {
        
    }

    public void DiscountPrice(int percent)
    {
        
    }
}

class Audio : Disk
{
    private string artist, recordingStudio;
    private int songsNumber;
    public Audio(string artist, string recordingStudio, int songsNumber, string name, string genre) : base(name, genre)
    {
        this.artist = artist;
        this.recordingStudio = recordingStudio;
        this.songsNumber = songsNumber;
    }

    public override int DiskSize => songsNumber * 8;

    public override void Burn(params string[] values)
    {
        artist = values[0];
        recordingStudio = values[1];
        songsNumber = int.Parse(values[2]);
        burnCount++;
    }

    public override string ToString()
    {
        return $"Name: {name}\nGenre: {genre}\nArtist: {artist}\nRecording studio: {recordingStudio}\nSongs number: {songsNumber}\nBurn count: {burnCount}\n";
    }
}

class DVD : Disk
{
    private string producer, filmCompany;
    private int minutesCount;

    public DVD(string producer, string filmCompany, int minutesCount, string name, string genre) : base(name, genre)
    {
        this.producer = producer;
        this.filmCompany = filmCompany;
        this.minutesCount = minutesCount;
    }
    
    public override void Burn(params string[] values)
    {
        producer = values[0];
        filmCompany = values[1];
        minutesCount = int.Parse(values[2]);
        burnCount++;
    }
    public override int DiskSize => (minutesCount / 64) * 2;


    public override string ToString()
    {
        return
            $"Name: {name}\nGenre: {genre}\nProducer: {producer}\nFilm company: {filmCompany}\nMinutes count: {minutesCount}\nBurn count: {burnCount}\n";
    }
    
}

class Store
{
    private string storeName, address;
    private Collection<Audio> audios = new Collection<Audio>();
    private Collection<DVD> dvds = new Collection<DVD>();

    public Store(string storeName, string address)
    {
        this.storeName = storeName;
        this.address = address;
    }

    public Collection<Audio> deleteAudio(Audio audio)
    {
        audios.Remove(audio);
        return audios;
    }

    public Collection<Audio> addAudio(Audio audio)
    {
        audios.Add(audio);
        return audios;
    }

    public Collection<DVD> deleteDVD(DVD dvd)
    {
        dvds.Remove(dvd);
        return dvds;
    }

    public Collection<DVD> addDVD(DVD dvd)
    {
        dvds.Add(dvd);
        return dvds;
    }

    public override string ToString()
    {
        string res = "";
        foreach (var audio in audios)
        {
            res += audio + "\n";
            
        }

        foreach (var dvd in dvds)
        {
            res += dvd + "\n";
        }
        return res;
    }
}