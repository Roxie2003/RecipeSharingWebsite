<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recipe.aspx.cs" Inherits="RecipeSharing.recipe" %>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Bootstrap Example</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        body {color:black;background-attachment: fixed;background-image: url('./Images/back.jpg');}
        .navbar {margin-bottom: 0;border-radius: 0;}
        hr {border-top:2px solid black;}
        .profileImg {border:1px solid black; border-radius:40px;height:80px;width:80px;}
        #recipeImage {border:2px solid black; }
        footer {background-color: #f2f2f2;color:black;padding: 15px;}
    </style>
    <script language="javascript" type="text/javascript">
    function confirmDelete() {
        if (confirm("Are you sure you want to delete!"))
            return true;
        return false;
        }

        function promptEmail()
        {
            var email = prompt("Enter Receiver Email Address");
            if (email.length === 0) {
                alert("Please enter a email.");
                return false;
            }
            document.getElementById('<%=receiverEmail.ClientID %>').value = email;
            return true;
        }
    </script>
</head>
<body align="center">

    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button><a class="navbar-brand" href="#">DamnDelicious</a></div>
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
            </div></div>
    </nav><br>
    <div class="container text-center" style="border:2px double white;border-radius:10px;padding:30px; background-color:white;color:black;">
        <form id="form1" runat="server" method="post">
        <h1 style="padding:20px;border:2px solid black;"><asp:Label ID="RecipeName" runat="server" Text="Label"></asp:Label></h1><br><br/>
                <div class="row" style="margin:0px 180px;border-radius:10px;background-color:black;color:white;" id="CreatorInfo" runat="server">
                    <div class="col-sm-2"><asp:Image runat="server" id="profilePhoto" class="profileImg" alt="Image"/></div>
                <div class="col-sm-8"><br>
                    <h4><asp:Label ID="username" runat="server" Text="Label"></asp:Label></h4>
                </div>
                <div class="col-sm-2"><br>
                    <asp:button Id="goToProfileBtn" class="btn btn-success" Text="Go to Profile" runat="server" OnClick="goToProfileBtn_Click"/>
                </div>
                </div>
               <div class="row" style="margin:15px 20px; "> 
              <div class="col-sm-4"><asp:Image id="recipeImage" runat="server" width="300px" height="300px"/><br><br></div>
            <div class="col-cm-8" style="text-align:left;padding:0px;">
                <asp:LinkButton ID="EditBtn"  class="btn btn-primary" runat="server" OnClick="EditBtn_Click" >Edit</asp:LinkButton>&nbsp &nbsp&nbsp &nbsp
                <asp:LinkButton ID="DelBtn"  class="btn btn-danger" runat="server" OnClientClick="return confirmDelete();" onClick="DelBtn_Click">Delete</asp:LinkButton>&nbsp &nbsp&nbsp &nbsp
                <asp:LinkButton ID="printBtn"  class="btn btn-success" runat="server" Text="Print" OnClientClick="window.print()" />&nbsp &nbsp&nbsp &nbsp
                <asp:LinkButton ID="mailBtn"  class="btn btn-danger" runat="server" Text="Share as Mail" OnClientClick="return promptEmail()" OnClick="mailBtn_Click" />
                <asp:HiddenField runat="server" ID="receiverEmail" />
                <hr/><h3><b><u>Description</u></b></h3>
                <asp:Label ID="description" runat="server" Text="Label"></asp:Label><br /><hr><br />
                <asp:LinkButton Id="LikeBtn" class="btn btn-primary" runat="server" OnClick="LikeBtn_Click"><i class='fa fa-thumbs-up fa-3' aria-hidden='true'> Like</i></asp:LinkButton>&nbsp &nbsp
                <br/><br/>
                <asp:LinkButton id="BookmarkBtn" class="btn btn-success"  runat="server" OnClick="BookmarkBtn_Click"><i class='fa fa-bookmark fa-3' aria-hidden='true'> Add to Bookmarks</i></asp:LinkButton><br><br>
             </div>
            </div><hr>
             <div class="text-left ">
                 <h3><b><u>Ingredients</u></b></h3>
                <asp:Label ID="ingredients" runat="server" Text="Label"></asp:Label><br/><br/>
                 <h3><b><u>Directions</u></b></h3>
                <asp:Label ID="directions" runat="server" Text="Label"></asp:Label>
            </div>
          </form>
        </div><br><br><br>
    <footer class="container-fluid text-center"><p>Copyright</p></footer>
</body>
</html>