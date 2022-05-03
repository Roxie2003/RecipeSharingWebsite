<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="following.aspx.cs" Inherits="RecipeSharing.following" %>

<!DOCTYPE html>

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
        body {
            color: white;
            background-attachment: fixed;
            background-image: url('./Images/back.jpg');
        }
        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }
        .profileImg {
                border:1px solid black;
                border-radius:40px;
                height:80px;
                width:80px;
        }
        button {
        width:650px;
        }
        footer {
            background-color: #f2f2f2;
            color:black;
            padding: 15px;
        }

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
                </button>
                <a class="navbar-brand" href="#">Damn Delicious</a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li ><a href="Home.html">Home</a></li>
                    <li><a href="createRecipe.aspx">Create Recipe</a></li>
                    <li><a href="myCreations.aspx">My Creations</a></li>
                    <li class="active"><a href="following.aspx">Following</a></li>
                    <li><a href="bookmarks.aspx">Bookmarks</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="myProfile.aspx">Profile</a></li>
                    <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-in"></span> Logout</a></li>
                </ul>
            </div>
        </div>
    </nav><br><br />
    <div class="container-fluid bg-3 text-center" style="margin:10px 30px;padding:0px 50px;">
        <h1><b><u>Following</u></b></h1><br>
        <div class="container" style="color:black;">
        <form id="form1" runat="server">
            <div class="row" id="followings" runat="server"  style="color:black;">  
            </div>   
        </form>
        </div>
    </div><br><br><br><br><br><br><br><br><br><br><br><br>
    <footer class="container-fluid text-center" style="bottom:0px;">
        <p>Copyright</p>
    </footer>

</body>
</html>