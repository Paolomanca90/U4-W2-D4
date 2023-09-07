using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace U4_W2_D4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca.Start();
            Console.ReadLine();
        }
    }
}

class Documento
{
    public string Tipo { get; }
    public int Codice { get; }
    public string Titolo { get; }
    public DateTime Anno { get; }
    public string Settore { get; }
    public string Scaffale { get; }
    public bool Stato { get; set; }

    public Documento(){}
    public Documento(string tipo, int codice, string titolo, DateTime anno, string settore, string scaffale, bool stato)
    {
        Tipo = tipo;
        Codice = codice;
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Scaffale = scaffale;
        Stato = stato;
    }
}

class Prestito
{
    public string Nome { get; }
    public string Cognome { get; }
    public string Email { get; }
    public long NumeroTelefono { get; }
    public int DocumentoPreso { get; }

    public Prestito() { }
    public Prestito(string nome, string cognome, string email, long numeroTelefono, int documentoPreso)
    {
        Nome = nome;
        Cognome = cognome;
        Email = email;
        NumeroTelefono = numeroTelefono;
        DocumentoPreso = documentoPreso;
    }
}

 class Biblioteca
{
    static Random random = new Random();
    static int CodiceDocumento()
    {
        int i = random.Next(100000, 999999);
        return i;
    }

    static List<Documento> documenti = new List<Documento>()
    {
        new Documento ("Libro",CodiceDocumento(),"Storia di Mario Rossi",new DateTime(2021, 1, 1), "Biografie","1A",false),
        new Documento ("Libro",CodiceDocumento(), "Storia del fratello di Mario",new DateTime(2023, 1, 1), "Biografie","12F",true),
        new Documento ("DVD",CodiceDocumento(), "Come e' fatto il corpo umano",new DateTime(2006, 1, 1), "Scienze","5H",true),
        new Documento ("DVD",CodiceDocumento(), "2 + 2 = 5",new DateTime(1980, 1, 1), "Matematica","8k",false),
        new Documento ("Libro",CodiceDocumento(), "Siti Web a 300€",new DateTime(2021, 1, 1), "Informatica","34L",false),
        new Documento ("Libro",CodiceDocumento(), "La guerra del Peloponneso",new DateTime(431, 1, 1), "Storia","9B",true),
        new Documento ("Libro",CodiceDocumento(), "Per andare dove dobbiamo andare...",new DateTime(1956, 1, 1), "Geografia","4C",true),
    };

    static List<Prestito> prestiti = new List<Prestito>() 
    { 
        new Prestito ("Luigi","Rossi","luigirossi@inferiore.com",1111111111,CercaCodice("Libro","Storia di Mario Rossi")),
        new Prestito ("Luigi","Rossi","luigirossi@inferiore.com",1111111111,CercaCodice("DVD", "2 + 2 = 5")),
        new Prestito ("Paolo","Manca","paolomanca1990@gmail.com",3880416518,CercaCodice("Libro", "Siti Web a 300€")),
    };


    static int CercaCodice(string tipo, string titolo)
    {
        int i = 0;
        foreach(Documento documento in documenti)
        {
            if(documento.Titolo == titolo && documento.Tipo == tipo)
            {
                i = documento.Codice;
                break;
            }
        }
        return i;
    }

    static void EffettuaPrestito()
    {
        Console.Write("Inserisci il codice del documento richiesto: ");
        int codice = Int32.Parse(Console.ReadLine());
        Prestito newPrestito = null;
        foreach(Documento documento in documenti)
        {
            if(documento.Codice == codice && documento.Stato)
            {
                Console.Write("Inserisci il nome del richiedente: ");
                string nome = Console.ReadLine();
                Console.Write("Inserisci il cognome del richiedente: ");
                string cognome = Console.ReadLine();
                Console.Write("Inserisci l'email del richiedente: ");
                string email = Console.ReadLine();
                Console.Write("Inserisci il numero di telefono del richiedente: ");
                long numero = long.Parse(Console.ReadLine());
                documento.Stato = false;
                Prestito prestito = new Prestito(nome, cognome, email, numero, codice);
                newPrestito = prestito;
                break;
            }
        }
        if(newPrestito != null)
        {
            prestiti.Add(newPrestito);
            Console.WriteLine($"Prestito del documento {codice} effttuato con successo.");
        }
        else
        {
            Console.WriteLine("Il documento richiesto al momento non e' disponibile.");
        }
    }

    static void Restituzione()
    {
        Console.Write("Inserisci il codice del documento che vuoi restituire: ");
        int codice = Int32.Parse(Console.ReadLine());
        Documento doc = null;
        foreach (Documento documento in documenti)
        {
            if (documento.Codice == codice)
            {
                doc = documento;
                break;
            }
        }
        if (doc != null)
        {
            Prestito newPrestito = null;
            foreach(Prestito prestito in prestiti)
            {
                if(prestito.DocumentoPreso == doc.Codice && !doc.Stato)
                {
                    doc.Stato = true;
                    newPrestito = prestito;
                    break;
                }
            }
            if (newPrestito != null)
            {
                prestiti.Remove(newPrestito);
                Console.WriteLine($"Il documento {newPrestito.DocumentoPreso} e' stato riconsegnato.");
            }
            else
            {
                Console.WriteLine($"Il documento {newPrestito.DocumentoPreso} non e' stato prestato.");
            }
        }
        else
        {
            Console.WriteLine("Il documento richiesto non e' stato trovato.");
        }
    }

    static void ListaPrestiti()
    {
        Console.WriteLine("====== Lista dei prestiti effettuati ======");
        Console.WriteLine();
        foreach(Prestito prestito in prestiti)
        {
            Console.WriteLine($"Documento {prestito.DocumentoPreso} in prestito a {prestito.Nome} {prestito.Cognome}.");
        }
    }

    static void DocumentiDisponibili()
    {
        Console.WriteLine("====== Documenti attualmente disponibili ======");
        Console.WriteLine();
        foreach(Documento documento in documenti)
        {
            if (documento.Stato)
            {
                Console.WriteLine($"Documento: {documento.Codice} - Tipo: {documento.Tipo} - Titolo: {documento.Titolo} - Anno: {documento .Anno.Year} - Scaffale: {documento.Scaffale}");
            }
        }
    }

    public static void Start()
    {
        while (true)
        {
            Console.WriteLine("++++++ Biblioteca Rossi ++++++");
            Console.WriteLine("1. Prendi in prestito un documento");
            Console.WriteLine("2. Restituisci un documento");
            Console.WriteLine("3. Mostra la lista dei prestiti attuali");
            Console.WriteLine("4. Mostra la lista dei documenti disponibili");
            Console.WriteLine("0. Esci");
            int scelta = Int32.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    EffettuaPrestito();
                    Console.WriteLine();
                    break;
                case 2:
                    Restituzione();
                    Console.WriteLine();
                    break;
                case 3:
                    ListaPrestiti();
                    Console.WriteLine();
                    break;
                case 4:
                    DocumentiDisponibili();
                    Console.WriteLine();
                    break;
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Arrivederci da Mario");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Scegli una delle opzioni disponibili");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
