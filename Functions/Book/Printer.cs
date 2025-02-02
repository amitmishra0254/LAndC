
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

interface Printer
{
    public void printPage(int page);
}
