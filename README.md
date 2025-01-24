# Moderne Architekturen und Designprinzipien
Kurs Repository zu Kurs .NET - Moderne Architekturen und Designprinzipien der ppedv AG

## Entwurfsmuster

- Creational Patterns: Wie werden Objekte erzeugt?
  - FactoryMethod DbClient Beispiel
  - FactoryMethod als PizzaShop
  - BuilderPattern als PizzaConfigurator
	
- Structural Patterns: Wie werden Objekte verbunden und integriert?
  - Decorator: Kaffee-Spezialitaet zusammenstellen
  - Adapter: Pfannen-Pizza als "normale" Pizza bestellen
	
- Behavioral Patterns: Wie verhalten sich Objekte und Objektstrukturen?
  - Strategy: Pizza mit einem Fahrzeug ausliefern

## Awesome Project: Rent a Brain

Wir verkaufen Rechenzeit an Kunden, die besonders hohe Ansprüche für mathematische Operationen haben, wie z. B. die Berechnung von Swing-By-Manövern.

- Domain
	- Klassendiagram mit draw.io angelegt
	- Domain-Modell aus Klassendiagram aus AI erzeugt
- Data Access
	- DbContext und Demo Daten erzeugt
	- Evtl. localdb Instanz erzeugen mit `sqllocaldb info|create|start|stop`
	- Migration aus Code first generieren lassen
	```sh
		dotnet tool install --global dotnet-ef
		dotnet ef migrations add <script-name> --project <BusinessLogic>
		dotnet ef database update --project <BusinessLogic>
	```
	- UnitTests gegen localdb