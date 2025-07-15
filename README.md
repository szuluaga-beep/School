
# C�mo Ejecutar el Proyecto  

Este proyecto est� construido usando .NET MVC y requiere SQL Express para la base de datos. Sigue los pasos a continuaci�n para configurar y ejecutar el proyecto:  

## Requisitos Previos  
- Instalar el SDK de .NET 8.  
- Aseg�rate de que SQL Express est� instalado y ejecut�ndose en tu m�quina.  

## Pasos para Ejecutar  

1. **Aplicar Migraciones**  
  Abre la terminal en el directorio del proyecto y ejecuta los siguientes comandos:  

2. **Poblar la Base de Datos**  
  El seed de la base de datos ocurrir� autom�ticamente cuando el proyecto se inicie. Aseg�rate de que las migraciones y la actualizaci�n de la base de datos est�n completadas antes de continuar.  

  `Update-Database`

3. **Ejecutar el Proyecto**  
  Inicia el proyecto usando el siguiente comando:  

4. **Acceder a la Aplicaci�n**  
  Abre tu navegador y navega a `http://localhost:7042` o al puerto especificado en la salida de la terminal.  

## Notas  
- No se requiere configuraci�n de Docker ni de bases de datos externas; SQL Express maneja la base de datos localmente.  
- Aseg�rate de que la cadena de conexi�n en `appsettings.json` est� configurada correctamente para SQL Express.


- **Capturas de Pantalla**  
  Aqu� hay algunas capturas de pantalla del proyecto en ejecuci�n:


<img width="1381" height="600" alt="image" src="https://github.com/user-attachments/assets/6e013102-c170-4511-9f7d-9518b5943c95" />


<img width="1445" height="836" alt="image" src="https://github.com/user-attachments/assets/7bc77892-3236-4882-90b4-35cf397d6359" />

<img width="1732" height="763" alt="image" src="https://github.com/user-attachments/assets/6e66937c-85ed-459f-aff4-4744b30649e5" />

<img width="1376" height="550" alt="image" src="https://github.com/user-attachments/assets/4c1373b6-4519-4b1f-88db-15a9ece69773" />
