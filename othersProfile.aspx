<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="othersProfile.aspx.cs" Inherits="RecipeSharing.othersProfile" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>Bootstrap Example</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        body {
            color:white;
            background-attachment:fixed;
            text-align:center;
            background-image:url('./Images/back.jpg');
        }
        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }
        footer {
            background-color: #f2f2f2;
            color:black;
            padding: 15px;
        }
    </style>
</head>
<body >
    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                  <a class="navbar-brand" href="#">DamnDelicious</a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="home.aspx">Home</a></li>
                    <li><a href="createRecipe.aspx">Create Recipe</a></li>
                    <li><a href="myCreations.aspx">My Creations</a></li>
                    <li><a href="following.aspx">Following</a></li>
                    <li><a href="bookmarks.aspx">Bookmarks</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="myProfile.aspx">Profile</a></li>
                                      <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-in"></span> Logout</a></li>

                </ul>
            </div>
        </div>
    </nav><br>
     <div class="container text-center" style="width:1080px;padding:10px;">
        <h1 style="padding:20px;border:2px solid white;"><b>Others Profile</b></h1><br><br/>
    <form id="form1" runat="server">
         <div class="row" style="margin:40px 20px; "> 
              <div class="col-sm-4">
              <asp:Image id="profilePhoto" runat="server" width="230px" height="230px"/><br><br />
              </div>
            <div class="col-cm-8" style="text-align:left;">
                <asp:LinkButton runat="server" Id="FollowBtn" class="btn btn-primary" OnClick="FollowBtn_Click">Follow +</asp:LinkButton><br><br>
                  <h4><b><u>Username</u></b></h4> <asp:Label ID="username" runat="server" Text=""></asp:Label><br>
               <br><hr>
                 <asp:Label ID="creations" runat="server" Text="Creations  0"></asp:Label>&nbsp 
                &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                &nbsp &nbsp &nbsp &nbsp &nbsp
                <asp:Label ID="followers" runat="server" Text="Followers  0"></asp:Label>&nbsp 
           &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                &nbsp &nbsp &nbsp &nbsp &nbsp
                <asp:Label ID="following" runat="server" Text="Following  0"></asp:Label>
                </div></div>
    </form>
     </div><hr>  
         <div>
         <h3><b>******************<u>Advertisement</u>******************</b></h3><hr>
		<asp:AdRotator Id="Ad1" runat = "server" AdvertisementFile = "ads.xml"  Target =  "_blank" Width="640" Height="240" BorderColor="white" borderwidth="10" BorderStyle="Outset"/>
    </div><br><br />


    <footer class="container-fluid text-center">
        <p>Copyright</p>
    </footer>

</body>
</html>