<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createRecipe.aspx.cs" Inherits="RecipeSharing.createRecipe" %>

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
        body {color:white;background-attachment:fixed;text-align:center;background-image:url('./Images/back.jpg');}
        .navbar {margin-bottom: 0;border-radius: 0;}
        textarea {margin-bottom:25px;resize: vertical;}
        footer {background-color: #f2f2f2;color:black;padding: 15px;}
    </style>
     <script>function preview() {
            frame.src = URL.createObjectURL(event.target.files[0]);
        }</script>
</head>
<body >
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
                    <li ><a href="home.aspx">Home</a></li>
                    <li class="active"><a href="createRecipe.aspx">Create Recipe</a></li>
                    <li><a href="myCreations.aspx">My Creations</a></li>
                    <li><a href="following.aspx">Following</a></li>
                    <li><a href="bookmarks.aspx">Bookmarks</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="myProfile.aspx">Profile</a></li>
                    <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-in"></span> Logout</a></li>
                </ul>
            </div> </div>
    </nav><br>
    <div class="container text-center">
        <form id="form1" runat="server">
        <h1 id="header" runat="server" style="padding:20px;border:2px solid white;"><b>Create New Recipe</b></h1><br><br />
        <div class="row" style="margin:0px 60px">
            <div class="col-sm-3"><div class="form-group">
              <asp:Image ID="frame" runat="server" width="250px" height="250px" /><br><br />
                <asp:FileUpload ID="FileUpload1" runat="server"  class="form-control-file" name="recipeImage" onchange="preview()"/>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="White" Display="Dynamic" ControlToValidate="FileUpload1" ErrorMessage="RecipeImage required"></asp:RequiredFieldValidator>
              </div></div>
        <div class="col-sm-9">
            <div class="form-group"><label class="control-label col-sm-3" for="recipeName">Recipe Name :</label>
            <div class="col-sm-9">
                <asp:TextBox id="recipeName" runat="server" class="form-control"  placeholder="Enter Recipe Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" controlToValidate="recipeName" ForeColor="White" Display="Dynamic" runat="server" ErrorMessage="Recipe name required"></asp:RequiredFieldValidator>            
            </div></div><br><br>
           <div class="form-group">
            <label class="control-label col-sm-3" for="description">Description :</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control"  id="description" name="description" placeholder="Enter Desciption" Height="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="White" Display="Dynamic" controlToValidate="description" ErrorMessage="Description required"></asp:RequiredFieldValidator>
            </div></div>
        </div> </div><hr />
        <div><br>
          <div class="form-group"> <label class="control-label col-sm-2" for="ingredients">Ingredients :</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control"  id="ingredients" name="ingredients" placeholder="Enter Ingredients"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="White" Display="Dynamic" ControlToValidate="ingredients" ErrorMessage="Ingredients Required"></asp:RequiredFieldValidator>
            </div></div><br><br>
            <div class="form-group"><br><br><label class="control-label col-sm-2" for="directions">Directions :</label>
            <div class="col-sm-10">
               <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" id="directions" name="directions" rows="15" placeholder="Enter Directions"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="White" Display="Dynamic" ControlToValidate="directions" ErrorMessage="Directions required"></asp:RequiredFieldValidator></div>
          </div><br><br>
          <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
              <asp:button runat="server" id="createRecipeBtn" onClick="createRecipeBtn_Click" Height=40px Width=90px class="btn btn-primary" Text="Submit"></asp:button>
                </div></div>
        </div>
</form></div><br><br><br>
    <footer class="container-fluid text-center"><p>Copyright</p></footer>
</body>
</html>
