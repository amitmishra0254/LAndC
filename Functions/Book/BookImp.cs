// Does this Book class follow SRP?  

/*
 * Answer: No
 * the given program not follows SRP principle, because into the given program, 
 * some books related operations are going on like getTitle, getAuthor, getCurrentPage, 
 * getLocation, turnPage and save. But we can devide all these operations into two parts.
 * First : The operations that are being used for geting book basic informations.
 * Second : The operations that can come with some complex logics. e.g. turnPage.
 * 
 * 
 * For following the SRP principle, below is the updated code.
 */

class BookImp : Book
{
    public string title { get; set; }
    public string author { get; set; }
    public int currentPage { get; set; }

    public BookImp(string title, string author, int currentPage)
    {
        this.author = author;
        this.title = title;
        this.currentPage = currentPage;
    }

    public string getTitle()
    {
        return this.title;
    }

    public string getAuthor()
    {
        return this.author;
    }

    public int getCurrentPage()
    {
        return this.currentPage;
    }
}
