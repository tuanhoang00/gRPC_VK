// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using Product_VK.Protos;
using System.Threading.Tasks;




Thread.Sleep(2000);

//Console.WriteLine("Hello, World!");

// create client grpc
using var channel = GrpcChannel.ForAddress("https://localhost:7101");
var client = new VKProtoService.VKProtoServiceClient(channel);




// grpc get VK information test function

/*
var response =  client.GetVK_Test(
    new GetVKRequest
    {
        IDVK = 2
    });
  
Console.WriteLine(response.ToString());



/*


/// <summary>
/// gRpc get VK infor function
/// input: ID_VK
/// output: information of VK 
/// </summary>



/*
var response_2 = client.GetVK(
    new GetVKRequest
    {
        IDVK = 3
    });


Console.WriteLine(response_2.ToString());
*/



/// <summary>
/// gRpc update VK information function
/// input: ID_VK
/// output: status of update 
/// </summary>


/*
var response_update = client.UpdateVK(
    new UpdateVKRequest
    {
        VK = new VKModel
        {
            VKID = 3,
            NameVK = "sung ban tia   ",
            NameOther = "Sungtruong",
            DescriptionVK = "Description",
            AccessoriesVK = "ACC",
            ImageVK = "Image",
            NoteVK = "Note",
            IDGroupVK = 1,
            WeightVK = 100,
            WidthVK = 100,
            HeightVK = 100,
            DepthVK = 100,
            RangeOperation = 13
        }
    });
*/



/// <summary>
/// gRpc delete VK information function
/// input: ID_VK
/// output: status of delete 
/// </summary>

/*

var response_delete = client.DeleteVK(new DeleteVKRequest
{
    IDVK = 5
});

Console.WriteLine(response_delete.ToString());

*/



/// <summary>
/// gRpc get all VK information function
/// input: none
/// output: all record of VK information in database 
/// </summary>


// get all vk information
Console.WriteLine("Get all VK information start... ");
using (var clientData = client.GetAllVK(new GetAllVKRequest()))
{
    
    while (await clientData.ResponseStream.MoveNext(new System.Threading.CancellationToken()))
    {
        var currentVK = clientData.ResponseStream.Current;
        Console.WriteLine(currentVK.ToString());
    }

}



/// <summary>
/// gRpc add VK information function
/// input: VK information
/// output: status of add 
/// </summary>


/*
var response_add = client.AddVK(
    new AddVKRequest
    {
        VK = new VKModel
        {
            VKID = 5,
            NameVK = "dan   ",
            NameOther = "Sungtruong",
            DescriptionVK = "Description",
            AccessoriesVK = "ACC",
            ImageVK = "Image",
            NoteVK = "Note",
            IDGroupVK = 1,
            WeightVK = 100,
            WidthVK = 100,
            HeightVK = 100,
            DepthVK = 100,
            RangeOperation = 13
        }
    });
Console.WriteLine(response_add.ToString());
*/



/// <summary>
/// gRpc insert list of VK information function
/// input: list of VK information
/// output: status of insert 
/// </summary>


Console.WriteLine("Insert list of vk testing");

using var clientBulk = client.InsertBulkVK();
for (int i = 0; i < 2; i++)
{
    var VKInfor = new VKModel
    {
        VKID = i + 5,
        NameVK = "sung ban tia   ",
        NameOther = "Sungtruong",
        DescriptionVK = "Description",
        AccessoriesVK = "ACC",
        ImageVK = "Image",
        NoteVK = "Note",
        IDGroupVK = 1,
        WeightVK = 100,
        WidthVK = 100,
        HeightVK = 100,
        DepthVK = 100,
        RangeOperation = 13
    };

    await clientBulk.RequestStream.WriteAsync(VKInfor);
}

await clientBulk.RequestStream.CompleteAsync();
var responseBulk = await clientBulk;

Console.WriteLine("result of insert bulk test '{0}'", responseBulk);





//reading a file excel then insert to sql server through grpc


Console.ReadLine();