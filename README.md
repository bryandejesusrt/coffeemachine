# ☕ Máquina de Café con T.D.D. 🍵

Este proyecto implementa una máquina dispensadora de café utilizando la metodología de desarrollo guiado por pruebas (Test Driven Development - T.D.D.). La aplicación consta de clases para los vasos, la cafetera, el azucarero y la máquina de café, con el objetivo de permitir al consumidor personalizar su experiencia al tomar un vaso de café.

## Funcionalidades

1. **Seleccionar el Tamaño del Vaso:**
   - Vaso Pequeño: 3 Oz de café.
   - Vaso Mediano: 5 Oz de café.
   - Vaso Grande: 7 Oz de café.

2. **Seleccionar Cucharadas de Azúcar.**
   
3. **Recoger Vaso.**

## Historia de Usuario

**Como:** Consumidor de café  
**Deseo:** Tomar un vaso de café  
**Para:** Mitigar el sueño.

## Criterios de Aceptación

- Se puede seleccionar entre 3 tamaños de vaso (Pequeño, Mediano, Grande).
- Se puede seleccionar la cantidad de azúcar.
- La máquina muestra un mensaje si no hay vasos, azúcar o café disponibles.

## Estructura del Proyecto

El proyecto está estructurado en clases que representan los componentes principales de la máquina de café:

- `Vasos`: Maneja la disponibilidad y el descontado de vasos.
- `Cafetera`: Gestiona la cantidad de café disponible y su descontado.
- `Azucarero`: Administra la cantidad de azúcar disponible y su descontado.
- `MaquinaDeCafe`: La máquina principal que coordina la preparación del café.

## Uso

1. **Clonar el Repositorio:**
   ```bash
   git clone https://github.com/tu-usuario/maquina-de-cafe-tdd.git```

 ### Compilar y Ejecutar:

```bash
cd maquina-de-cafe-tdd
dotnet run
```
### Seguir las Instrucciones del Menú:
- Seleccionar la opción "Preparar café".
- Elegir el tamaño del vaso.
- Ingresar la cantidad de café y azúcar.

### Pruebas Unitarias
Se han incluido pruebas unitarias utilizando NUnit. Para ejecutar las pruebas, utiliza el siguiente comando:

```
bash
dotnet test
```
</br>
### Contribuciones
¡Las contribuciones son bienvenidas! Si encuentras un problema o tienes sugerencias de mejora, por favor abre un problema o envía una solicitud de extracción.


## ¡Disfruta de tu café y feliz codificación! ☕🚀

