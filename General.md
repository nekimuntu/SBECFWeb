﻿Installe AutoMapper pour faciliter le chargement des entites liees 
J installe via Nugget

Pour la mise en production il faut veiller a ajouter: 
1/ app.UseDefaultFiles()

2/
ajouter un controller responsable de deleguer le routage de certaines URL a React : 

[AllowAnonymous] //Tres important de rajouter cela sinon le server va bloquer toutes les connexions(impossible d avoir acces au frontend)
class FallBackController:Controller{

	public IActionResult Index(){
		return PhysicalFile(Path.Combine(Directory.CurrentDirectory(), 'wwwroot', "index.html", "text/HTML"));

3/ 
On inject dans le programme le tout nouveau controller 

app.MapFallBackController("Index","FallBack")
							nom de la methode, nom du controller

4/ creation des mock Utilisateurs 

Pour Seeder des utilisateur on a besoin d injecter un UserManager<Utilisateur> dans Seed.cs





