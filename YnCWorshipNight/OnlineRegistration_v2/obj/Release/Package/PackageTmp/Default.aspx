
<%@ Page Title="Welcome to PD OMPKK YnC Home Page" Language="C#" AutoEventWireup="true" Inherits="OnlineRegistration_v2.Response" %>

<!DOCTYPE html>
<html>
<head>
	<title>Home Page</title>
	<style type="text/css">
	@import url('https://fonts.googleapis.com/css?family=Montserrat');

	html,body{
		margin: 0;
		padding: 0;
		height: 100%;
		width: 100%;
	}

	.intro{
		height: 100%;
		width: 100%;
		margin: auto;
		background-color: #ffafa2;
		display: table;
		top: 0;
	}

	.intro .inner {
		display: table-cell;
		width: 100%;
		max-width: none;
		vertical-align: middle;
		text-align: center;
	}

	.content {
		max-width: 100%;
		margin: 0 auto;
	}

	.getTickets{
		background-color: #0d2481;
		color: #FFFFFF;
		padding: 10px;
		font-weight: bold;
		border: solid 3px #FFFFFF;
	}

	.btn-1a:hover,
	.btn-1a:active {
		color: #0e83cd;
		background: #fff;
	}

	.imageLogo{
		width: 30%;
	}

	@media only screen and (max-width: 768px) {
		.imageLogo {
			width: 50%;
		}
	}

	@media only screen and (max-width: 450px) {
		.imageLogo {
			width: 60%;
		}
	}

</style>
</head>
<body>
	<section class="intro">
		<div class="inner">
			<div class="content">
				<img src="http://pdompkkync.com/Images/rejoice_logo.svg" class="imageLogo">
				<br>
				<br>
				<h1 style="font-family: 'Montserrat',sans-serif;">15 September 2018 | @ Aula Sekolah St John BSD</h1>		
				<a href="http://pdompkkync.com/registration.aspx"><button class="getTickets btn-1a">GET MY FREE TICKET!</button></a>
                <br>
                <br>
                <iframe width="560" height="315" src="https://www.youtube.com/embed/B6A2Zf6UqXU" frameborder="0" allowfullscreen></iframe>
			</div>
		</div>
	</section>
</body>
</html>