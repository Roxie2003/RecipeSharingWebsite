<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="RecipeSharing.signup" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml"  lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Sign Up Form </title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css">
    <link rel="stylesheet" href="css/style.css">
</head>
        <style>
        body {
            color:black;
            background-attachment: fixed;
            background-image: url('./Images/back.jpg');
        }</style>
       <script>function preview() {
            frame.src = URL.createObjectURL(event.target.files[0]);
        }</script>
<body>
       <nav class="navbar navbar-inverse">
        <div class="container-fluid"><div class="navbar-header">
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
                </ul>
            </div></div>
    </nav><br>

    <div class="main" style="padding:40px;background-color:transparent;">
        <section class="signup">
            <div class="container text-center"><br>
                 <img src="./Images/untitled1.png" width="850" height="100">
                 <form method="POST" runat="server" class="register-form" id="form1" >
                <div class="signup-content" style="padding:20px;"> <div class="signup-form">
                        <h2 class="form-title">Sign up</h2>
                       <div class="form-group">
                             <label for="your_name"><i class="zmdi zmdi-account material-icons-name"></i></label>
                                <asp:TextBox name="your_name" id="your_name" placeholder="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ForeColor="red"  controlToValidate="your_name" ErrorMessage ="*Username is required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="email"><i class="zmdi zmdi-email"></i></label>
                                <asp:TextBox name="your_email" id="your_email" placeholder="Your Email"  runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ForeColor="red"  controlToValidate="your_email" ErrorMessage="*Email is Required" ></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red" ControlToValidate="your_email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter valid Email Address"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="your_pass"><i class="zmdi zmdi-lock"></i></label><br/>
                                <asp:TextBox name="your_pass" id="your_pass" placeholder="Password"  runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ForeColor="red"  controlToValidate="your_pass" ErrorMessage="*Password is Required"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="red" controlToValidate="your_pass" Display="Dynamic" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$" ErrorMessage="Password length 4-8 charcaters.Include 1 uppercase,lowercase & digit"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="your_re_pass"><i class="zmdi zmdi-lock-outline"></i></label><br/>
                                <asp:TextBox name="your_re_pass" id="your_re_pass" placeholder="Repeat your password"  runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ForeColor="red"  controlToValidate="your_re_pass" ErrorMessage="*ReType Password is Required"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ForeColor="red" ErrorMessage="Password and ReType Password do not match" ControlToCompare="your_pass" ControlToValidate="your_re_pass"></asp:CompareValidator>
                            </div>    
                            <div class="form-group form-button">
                                <asp:Button runat="server" name="signUp" id="signupBtn" class="form-submit" Text="Sign Up" OnClick="signupBtn_Click"/>
                            </div>
                    </div>
                    <div class="signup-image">
                        <div class="form-group">
                          <asp:Image ID="frame" runat="server" width="250px" height="250px" /><br><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="red" controlToValidate="FileUpload1" ErrorMessage="*Profile Photo is required"></asp:RequiredFieldValidator>
                            <asp:FileUpload ID="FileUpload1" runat="server" Height="83px"  class="form-control-file" name="profilePhoto" onchange="preview()"/>
                        </div>
                        <a href="login.aspx" class="signup-image-link">I am already member</a>
                    </div></div>
            </form></div>
        </section>
    </div>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>

