<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="RecipeSharing.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head>
    <title>Bootstrap Example</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        body {color: white;background-attachment: fixed;background-image: url('./Images/back.jpg');}
        .navbar { margin-bottom: 0;border-radius: 0;}
        img {border-radius:5px;border:2px solid white;}
        footer {background-color: #f2f2f2;color:black;padding: 15px;}
        .recipe{width:300px; }
    </style>
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
    </nav><br><br />

    <div class="container" style="background-image:url('./Images/homeback.jpg');background-size:100%;padding:180px 150px; color:black;">
        <div class="brand"><h1><b>Damn Delicious</b></h1>
            <h4>A Recipe has no Soul<br>You as the Cook, must bring the Soul to the Recipe</h4>
        </div>
    </div><br><br><br><br>
   
    <div class="container" style="width:500px;">
        <form method="post" action="home.aspx"><div class="input-group">
                <input ID="search" name="search" class="form-control" placeholder="Search"></input>
                <div class="input-group-btn">
                    <button ID="searchBtn" class="btn btn-primary" ><i class="glyphicon glyphicon-search"></i></button>
                </div></div>
        </form>
    </div>
    <div class="container-fluid bg-3 text-center" style="margin:10px 30px;padding:30px 50px;" id="Content" runat="server">
    <form id="form1" runat="server" >
        <div class="row" style="color:black;" id="trending" runat="server" >
        </div>
        <div class="row" id="latestCreations" runat="server"  style="color:black;">  
        </div>   
        <br><br>
    </form></div>
    <div>
        <form><button formaction="createRecipe.aspx" class="btn btn-primary" style="position: fixed; bottom: 20px; right:20px; margin-left: -104.5px; border-radius: 50%;"><i style="font-size:30px" class="fa fa-plus fa-6" aria-hidden="true"></i></button></form>
    </div>
    <footer class="container-fluid text-center">
        <p>Copyright</p>
    </footer>
</body>
</html>
