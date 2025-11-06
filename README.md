# 📘 Sistema de Gestión Escolar — Colegio San José

Este sistema web fue desarrollado como parte del proyecto académico de la materia **Desarrollo de Aplicaciones con Software Propietario DAS901 G01T (Virtual)**. Su propósito es facilitar la administración de alumnos, materias y expedientes académicos, con una interfaz moderna, clara y profesional.

---

## 🧩 Características Principales

- Gestión completa de **Alumnos**, **Materias** y **Expedientes**.
- Visualización de **promedios por alumno** con gráficos interactivos (barras, radar).
- Interfaz responsiva y profesional con **Bootstrap 5**.
- Arquitectura basada en **ASP.NET Core MVC** y **Entity Framework Core**.
- Base de datos relacional en **SQL Server**.
- Separación de lógica con **ViewModels**, **LINQ projections** y patrón **DAO**.
- Validaciones robustas, flujos de confirmación elegantes y presentación lista para defensa académica.

---

## 📦 Instalación

### Requisitos

- Visual Studio 2022 o superior
- .NET 7.0 SDK
- SQL Server (Express o LocalDB)
- Navegador moderno (Chrome, Edge, Firefox)

### Pasos

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/usuario/colegio-san-jose.git
   ```
2. Abrir el proyecto en Visual Studio
3. Configurar la cadena de conexion en appsettings.json:
```Json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ColegioSanJoseDB;Trusted_Connection=True;"
}
```
4. Ejecutar las  migraciones:
```bash
dotnet ef database update
```
5. Ejecutar la aplicacion:
```bash
dotnet run
```


### Módulos disponibles

- 📋 **Alumno**  
  - Crear, editar, eliminar y visualizar fichas de alumnos.  
  - Validaciones en formularios y presentación profesional con Bootstrap 5.

- 📚 **Materia**  
  - Gestión de asignaturas: alta, modificación y eliminación.  
  - Interfaz clara y coherente con el resto del sistema.

- 🗂️ **Expediente**  
  - Registro de notas finales y observaciones por alumno y materia.  
  - Flujos de confirmación elegantes y validaciones robustas.

- 📊 **Promedios**  
  - Visualización gráfica de promedios por alumno.  
  - Gráficos interactivos con Chart.js (barras y radar).  
  - Tabla de resumen con badges para destacar aprobados y reprobados.

### Navegación

- Todos los módulos están accesibles desde el menú principal.
- Las vistas están optimizadas para presentación académica y defensa profesional.
- Los formularios incluyen retroalimentación visual, íconos, y estructura clara.

## 👨‍💻 Autor

**Fernando José Gómez Hernández**  - GH251230
Proyecto académico desarrollado para la materia  
**Desarrollo de Aplicaciones con Software Propietario DAS901 G01T (Virtual)**  
**Colegio San José — Año 2025**

Este sistema forma parte de una entrega académica orientada a demostrar competencias en desarrollo web con tecnologías propietarias, arquitectura MVC, diseño profesional con Bootstrap, y presentación de datos con gráficos interactivos.

---

