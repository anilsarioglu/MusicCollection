# MusicCollection
School assignment

# Portfolio Programmeren in .NET

ASP.NET MVC app voor beheren van een muziekcollectie

Voor je portfolio dien je met behulp van Entity Framework en ASP.NET MVC een app te maken die een gebruiker de mogelijkheid geeft om zijn muziekcollectie zelf te beheren. 

Je portfolio moet bestaan uit volgende onderdelen:

- Je ERD
- Een SQL script dat de database aanmaakt op eender welke SQL Server
- Een zip-bestand met daarin je volledige solution
- Een bondige maar duidelijke gebruikershandleiding van je applicatie
- Een begeleidend document waarin je toelicht in welke bestanden je gebruik hebt gemaakt van een inline query en stored procedure call.

Bij het uitwerken van de app dien je rekening te houden met volgende zaken:

* Databank
  * Je ontwerpt zelf een databank waarin de gebruiker de nodige gegevens kan bewaren. Je werkt hiervoor eerst een ERD uit die je via mail ter validatie voorlegt aan de lector.
  * Je database dient minimum uit 4 tabellen te bestaan waarbij minstens 1 één-op-meer relatie bestaat tussen deze tabellen.
  * Je gebruikt als database SQL Server.
  * Je zorgt bij je portfolio voor een SQL script dat alle statements bevat om de initiële database aan te maken op eender welke computer. Dit script dien je te genereren met behulp van Entity Framework. Je werkt dus code-first!
 
* Applicatie
  * Je voorziet minimum een eenvoudige, duidelijke menu structuur om elke bewerking in je app te kunnen uitvoeren.
  * Je voorziet een basis CRUD gebruikersinterface voor elke entiteit in je applicatie. Dit is het meest belangrijke stuk.
  * Je voorziet indien mogelijk/haalbaar ook features om bulk insert via CSV bestanden uit te kunnen voeren voor entiteiten waar dit opportuun is. Hou ook hier rekening met data validatie!
  * Je werkt een gebruiksvriendelijke gebruikersinterface uit. Hou rekening met volgende zaken:
    * Duidelijk
    * Eenvoudig in gebruik
    * Consistent
    * Validatie van gebruikersinput
    
* Technisch:
  * Werk een duidelijke professionele architectuur uit voor je applicatie. (bv aparte laag voor entiteiten, aparte laag voor data access)
  * Werk je data laag uit in functie van een disconnected model
  * Voorzie minstens 1 zelf uitgewerkte inline query in je data laag, gebruik makend van Entity Framework (geen pure ADO.NET gebruiken!)
  * Voorzie minstens 1 stored procedure call in je data laag, gebruik makend van Entity Framework (geen pure ADO.NET gebruiken!).
