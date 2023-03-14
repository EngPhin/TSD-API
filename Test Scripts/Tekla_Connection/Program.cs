using TSD.API.Remoting;
using System;


namespace Tekla_Connection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tsdInstances = await ApplicationFactory.GetRunningApplicationsAsync();

            if( tsdInstances.Any() )
            {
                var tsd = tsdInstances.First();

                // async methods take time to run, so need to add an await statement to tell the compiler to wait till this method is done running before you assign its output so the variable. 
                // otherwise, it returns a variable of type 'Task' and not what you actually want.  
                var document = await tsd.GetDocumentAsync();

                if( document != null )
                {
                    var title = await tsd.GetApplicationTitleAsync();
                    System.Console.WriteLine($"Model file title: {title}.");

                    var model = await document.GetModelAsync();
                    var members = await model.GetMembersAsync();
                    Console.WriteLine( $"Number of members in the model: {members.Count()}" );
                }
            }
            else
            {
                Console.WriteLine( "No running instance of Tekla Structural Designer found!" );
            }        
        }
    }
}


// ## can also write it outside like so:

// var tsdInstances = await ApplicationFactory.GetRunningApplicationsAsync();

// if( tsdInstances.Any() )
// {
//     // Here we simply get first instance found
//     var tsd = tsdInstances.First();

//     var document = await tsd.GetDocumentAsync();

//     // And if there is a document
//     if( document != null )
//     {
//         var title = await tsd.GetApplicationTitleAsync();
//         System.Console.WriteLine(title);
//         // then we get its model
//         var model = await document.GetModelAsync();

//         // and from the model all members
//         var members = await model.GetMembersAsync();

//         // Finally we print total amount of members to standard output
//         Console.WriteLine( $"Members in the model: {members.Count()}" );
//     }
// }
// else
// {
//     Console.WriteLine( "No running instance of Tekla Structural Designer found!" );
// }        

