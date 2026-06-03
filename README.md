🏚️ Trapped Inside

Trapped Inside es un juego de terror psicológico tipo escape room desarrollado en Unity.
El jugador despierta en una casa desconocida y debe explorar, resolver puzzles y encontrar la forma de escapar mientras evita a las entidades que habitan el lugar.

⸻

🎮 Gameplay

* Exploración en primera persona
* Interacción con objetos mediante raycast
* Resolución de puzzles ambientales
* Sistema de vida y daño
* Enemigos con navegación mediante NavMesh
* Uso de sonido, iluminación y UI para generar tensión

⸻

🧩 Características implementadas

* ✔️ Menú principal, pausa y opciones
* ✔️ Control de volumen
* ✔️ Sonido ambiental y efectos de sonido
* ✔️ Sistema de interacción por Raycast
* ✔️ Sistema de vida y muerte
* ✔️ Barra de vida del jugador
* ✔️ Puzzle de llave y estantería secreta
* ✔️ Puertas bloqueadas y progresión por objetivos
* ✔️ Sistema de diálogos y pensamientos
* ✔️ Pantalla de victoria y derrota
* ✔️ Gestión correcta del cursor e input FPS

⸻

🤖 Enemigos

Hunter

* Patrulla el escenario
* Detecta y persigue al jugador
* Ataca y causa daño
* Regresa a patrullar al perder al jugador

Corpse

* Permanece inactivo al inicio
* Se activa al acercarse el jugador
* Ejecuta una animación de levantarse
* Patrulla, persigue y ataca

⸻

🎯 Vertical Slice

La versión actual incluye:

* Movimiento en primera persona
* Menu principal y de pausa
* UI de victoria y de muerte
* Interacción con objetos
* Puzzles básicos
* Sistema de vida y combate
* Múltiples enemigos con comportamientos distintos
* Sonido ambiental y efectos de audio
* Condiciones de victoria y derrota
* Escenario completamente jugable

⸻
## ⌨️ Controles

| Acción | Tecla |
|----------|----------|
| Moverse hacia adelante | W |
| Moverse hacia atrás | S |
| Moverse a la izquierda | A |
| Moverse a la derecha | D |
| Saltar | Space |
| Sprint | Shift |
| Mirar alrededor | Mouse |
| Interactuar / Recoger objetos | E o Click Izquierdo |
| Encender / Apagar linterna | Click Izquierdo |
| Pausar juego | ESC |

---
---

## 📥 Clonar el Proyecto

Este proyecto utiliza **Git LFS (Large File Storage)** para almacenar modelos, animaciones y otros archivos de gran tamaño.

### 1. Instalar Git LFS

Antes de clonar el repositorio, instala Git LFS:

#### Windows
https://git-lfs.com/

#### macOS

```bash
brew install git-lfs
```

#### Linux

```bash
sudo apt install git-lfs
```

### 2. Inicializar Git LFS

```bash
git lfs install
```

### 3. Clonar el repositorio

```bash
git clone https://github.com/Hanselopez99/TrappedInside.git
```

o usando SSH:

```bash
git clone git@github.com:Hanselopez99/TrappedInside.git
```

### 4. Descargar los archivos LFS

Si los archivos grandes no se descargan automáticamente:

```bash
git lfs pull
```

También puedes forzar la descarga de todos los archivos:

```bash
git lfs fetch --all
git lfs checkout
```

### 5. Abrir el proyecto

Abrir la carpeta del proyecto desde **Unity Hub** utilizando la versión:

```text
Unity 6
```

---
⸻

🖥️ Motor de Desarrollo

* Unity 6

👨‍💻 Autor

Hansel Andre López Montenegro


👉 **Video del juego:**  
[![Trapped Inside Gameplay](https://youtu.be/idfBU7fZcaw)](https://youtu.be/idfBU7fZcaw))