# Ismétlés

```
 +------------------------------+    +---------------------------+
 | Internet böngésző            |    | ASP.NET MVC webalkalmazás |
 |------------------------------|    |---------------------------|
 |                              |    |                           |
 | +-------------------------+  |http|  +------------+           |
 | |  HTML állomány a válasz |  |+-->|+->Útválasztás |+----+     |
 | |                         |  |    |  +------------+     v     |
 | |                         |<-+<--+| +--------+ +------------+ |
 | |                         |  |    | |Layout  | |            | |
 | |                         |  |    <-++       | | Controller
 | |                         |  |    | |View    <-+ + Action   | |
 | +-------------------------+  |    | |        | |            | |
 |                              |    | +--------+ +------------+ |
 +------------------------------+    +---------------------------+
```

# Az étterem projekt leírása (specifikáció)

## Képernyőképek
képernyőképeket nem készítünk mert az alkallmazás varázsló elkészíti őket

## Szereplő listája
## érdeklődő
## étlap
### példa étlap

- Pizzák
  - margarita pizza 200 Ft
    - mozarella sajt, pizzaszósz
  - hawaii pizza 300 Ft
    - sonka, ananász, mozarella sajt, pizzaszósz

- Italok
  - ásványvíz 100 Ft (3dl)
  - cola 1200 Ft (3dl)

## vendég
## személyzet

## Forgatókönyvek

### Érdeklődő eldönti, hogy akar-e nálunk enni
- érdeklődő elkéri az étlapot 


# Code First Migration
kell hozzá
- entity framework
- code first migration engedélyezése: pacakge manager console-ból projektenként
- ezzel létrejön egy Migrations könyvtár, ez alatt a Configuration.cs állomány
- ha már létezik adatbázis, akkor automatikusan létrejön az első migrationStep
- ha nincs első migrációs lépés, akkor kézzel készítünk consoleból add-migration 'migrációnév' állományt
- végül létrehozzuk az adatbázist az update-database paranccsal

Az utolsó három lépés az ASP.NET identity miatt kell (login, register), 
az adatbázist pedig az *SQL Server Object Explorer ablakban látjuk a localdb csomópont alatt. Lehet, hogy frissítenünk kell.

```
                 +---------------+              +------------------+
                 | Add-Migration |              | Update-Database  |
                           +------------+       +------------------+
   +------------------+    | MigrStep 1 |                                   +--------------+    +
   | Model            |    |------------|                                   |              |    |
   |------------------|    |            |    +-------------------------->   | SQL script 1 |    |
   |                  |+-> |            |                                   |              |    |
   |  Category        |    |            |                                   +--------------+    |
   |                  |    +------------+                                                       |
   |                  |                                                                         |
   |                  |    +------------+                                                       |
   |                  |    | MigStep 2     |                                                       |
   |                  |    |------------|                                   +--------------+    |
   |                  |+-> |            |   +--------------------------->   |              |    |
   |                  |    |            |                                   | SQL script 2 |    |
   |                  |    |            |                                   |              |    |
   +------------------+    +------------+                                   +--------------+    |
                    +                                                                           |
                    |      +------------+                                                       |
                    |      | MigrStep 3 |                                   +---------------+   |
                    |      |------------|                                   |               |   |
                    |      |            |   +--------------------------->   | SQL script 3  |   |
                    +----->|            |                                   |               |   |
                           |            |                                   +---------------+   |
                           +------------+                                                       v
                                                                     +-----------------------------+
                                                                     |  SQL ADATBÁZIS              |
                                                                     |-----------------------------|
                                                                     |                             |
                                                                     +-----------------------------+
```

Lehetőség van visszafelé is migrálni, ez esetben -> update-database -Targetmigration 0
vagy
update-database -TargetMigration 'fájl neve'

update-database -Script -> megmutatja a létrehozott sql scriptet, de nem futtatja le

## Saját adatbázisba tétele
- létre kell hozni egy osztály ami az adatokat tartalmazza
- az applicationcontext-be kell felvenni dbset property-vel (identityModels.cs)
- ki kell adni az add-migration és update database parancsot
