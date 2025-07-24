# Cat Giphy App 

Aplicación construida con **.NET 9 (backend)** y **React + TypeScript (frontend)**. 
Consume datos de dos APIs públicas (Cat Facts y Giphy) y guarda el historial de búsquedas en **MongoDB Atlas** (Base de datos de mongodb en la nube) manteniendo la persistencia requerida.


SE ADJUNTA UN VIDEO MOSTRANDO  LA CORRECTA FUNCIONALIDAD DE TODO LO REQUERIDO EN LA PRUEBA TECNICA PARA EL DESARROLLO DEL PROYECTO 

https://drive.google.com/file/d/1HZhdxk65WkDuys62gPB8IN1nmq4MV9GZ/view?usp=drive_link

---

##  Tecnologías usadas

- .NET 9 (Web API)
- React + TypeScript
- MongoDB Atlas
- Visual Studio 2022 y Visual Studio Code

---
## ¿Cómo ejecutar el proyecto localmente?

###  Backend (.NET)

1. Abrir la carpeta `/CatGiphyApi` en Visual Studio 2022.
2. Asegurar que de que el archivo `appsettings.json` contiene la conexión correcta a MongoDB Atlas. 
LA URI CORRECTA ES: mongodb+srv://MiguelPedraza:1193049655@cluster0.nbkhajg.mongodb.net/
3. Si gustan verificar los cambios de la base de datos, pueden hacerlo através de mongodb compass con la URI de conexión especificada anteriormente. 

4. Ejecutar el proyecto (`F5` o `Ctrl+F5`).

5. La API o url del backend estará disponible en: `https://localhost:7016/api`

6. De igual manera para probar las funcionalidades del backend se implementa swagger en: `https://localhost:7016/swagger/index.html`

###  Frontend (React)

1. Abrir una terminal en la carpeta `/cat-giphy-frontend`
2. Ejecutar:


```bash
npm install
npm run dev

