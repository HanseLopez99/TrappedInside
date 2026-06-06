# 🏚️ Trapped Inside

Trapped Inside es un juego de terror psicológico tipo escape room desarrollado en Unity.  
El jugador despierta en una propiedad desconocida y debe explorar, resolver puzzles y encontrar la forma de escapar mientras evita a las entidades que habitan el lugar y descubre qué está ocurriendo dentro de la casa.

---

## 🎮 Gameplay

- Exploración en primera persona
- Interacción con objetos mediante raycast
- Resolución de puzzles ambientales
- Sistema de vida y daño
- Enemigos con inteligencia artificial y navegación mediante NavMesh
- Eventos narrativos y cinemáticas in-game
- Uso de sonido, iluminación y UI para generar tensión

---

## 🧩 Características implementadas

- ✔️ Menú principal, pausa y opciones
- ✔️ Control de volumen
- ✔️ Sonido ambiental y efectos de sonido
- ✔️ Sistema de interacción por Raycast
- ✔️ Sistema de vida y muerte
- ✔️ Barra de vida del jugador
- ✔️ Sistema de linterna
- ✔️ Puzzle de llave y estantería secreta
- ✔️ Puertas bloqueadas y progresión por objetivos
- ✔️ Sistema de diálogos y pensamientos
- ✔️ Eventos narrativos contextuales
- ✔️ Sistema de alarma y luces de emergencia
- ✔️ Pantalla de victoria y derrota
- ✔️ Gestión correcta del cursor e input FPS
- ✔️ Sistema de inventario basado en ScriptableObjects
- ✔️ Sistema de pickups orientado a eventos
- ✔️ UI dinámica de inventario con iconos y nombres
- ✔️ Sistema de guardado y carga mediante JSON

---

## 🎒 Sistema de Inventario (Event & Data Driven)

El juego implementa un sistema de inventario basado en ScriptableObjects y eventos, permitiendo registrar y mostrar dinámicamente los objetos recolectados por el jugador.

### Pickups disponibles

- 🔦 Flashlight
- 🗝 Key
- 📸 Family Photo
- 📝 Note
- ✝ Cross

### Características

- ✔️ Cada pickup posee su propio modelo 3D dentro de la escena.
- ✔️ Cada pickup cuenta con un ScriptableObject asociado.
- ✔️ Los ScriptableObjects almacenan información del objeto como nombre e ícono.
- ✔️ Los objetos pueden ser recogidos mediante interacción por Raycast.
- ✔️ Al recoger un objeto se dispara un evento que actualiza automáticamente el inventario.
- ✔️ El inventario muestra en pantalla el nombre e ícono de cada objeto recolectado.
- ✔️ Los pickups pueden activar eventos dentro del juego, como desbloquear puertas o habilitar progresión.

### Arquitectura utilizada

- ItemData (ScriptableObject): almacena los datos de cada pickup.
- InventoryManager: administra los objetos recolectados.
- InventoryDisplay: actualiza dinámicamente la interfaz mediante eventos.
- PickupItem: comportamiento genérico para objetos coleccionables.
- UI Inventory Panel: representación visual del inventario del jugador.

---

## 💾 Sistema de Guardado (Save / Load)

El juego implementa un sistema de persistencia basado en archivos JSON que permite guardar y cargar el progreso del jugador.

### Datos almacenados

- Posición del jugador (X, Y, Z)
- Vida actual
- Estado de la linterna
- Estado de la llave
- Objetos registrados en el inventario

### Características

- ✔️ Clase serializable SaveData
- ✔️ Persistencia mediante archivos JSON
- ✔️ Guardado manual desde el menú de pausa
- ✔️ Carga manual desde el menú de pausa
- ✔️ Manejo de errores cuando no existe un archivo guardado
- ✔️ Restauración de la posición del jugador
- ✔️ Restauración de la vida del jugador
- ✔️ Restauración de estados importantes del juego

### Arquitectura utilizada

- SaveData: estructura serializable utilizada para almacenar la información del juego.
- PersistenceManager: responsable de guardar y cargar la información persistente.
- PlayerHealth: integración con el sistema de persistencia para restaurar la vida.
- Pause Menu: interfaz utilizada para ejecutar las acciones de guardado y carga.

---

## 🤖 Personajes y Navegación

### Hunter

- Patrulla el exterior de la casa
- Detecta al jugador
- Persigue utilizando NavMesh
- Ataca y causa daño
- Regresa a patrullar cuando pierde al jugador

### Corpse

- Permanece acostado al inicio
- Se activa al acercarse el jugador
- Ejecuta una animación de levantarse
- Patrulla, persigue y ataca

### Remy

- Personaje narrativo controlado mediante NavMesh
- Reacciona a la presencia del jugador
- Participa en una cinemática dentro de la casa
- Corre hacia la puerta principal y encierra al jugador

---

## 🎯 Vertical Slice

La versión actual incluye:

- Movimiento en primera persona
- Menú principal y menú de pausa
- UI de victoria y derrota
- Interacción con objetos
- Sistema de linterna
- Sistema de inventario y recolección de objetos
- Arquitectura Event & Data Driven mediante ScriptableObjects
- Sistema de guardado y carga mediante JSON
- Puzzles básicos
- Sistema de vida y combate
- Inteligencia artificial con múltiples comportamientos
- Navegación mediante NavMesh
- Sonido ambiental y efectos de audio
- Eventos narrativos
- Condiciones de victoria y derrota
- Escenario completamente jugable

---

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
| Guardar partida | Menú de Pausa → Save Game |
| Cargar partida | Menú de Pausa → Load Game |

---

## 📥 Clonar el Proyecto

Este proyecto utiliza Git LFS (Large File Storage) para almacenar modelos, animaciones y otros archivos de gran tamaño.

### 1. Instalar Git LFS

#### Windows

https://git-lfs.com/

#### macOS

bash brew install git-lfs 

#### Linux

bash sudo apt install git-lfs 

### 2. Inicializar Git LFS

bash git lfs install 

### 3. Clonar el repositorio

bash git clone https://github.com/Hanselopez99/TrappedInside.git 

o usando SSH:

bash git clone git@github.com:Hanselopez99/TrappedInside.git 

### 4. Descargar los archivos LFS

bash git lfs pull 

o

bash git lfs fetch --all git lfs checkout 

### 5. Abrir el proyecto

Abrir la carpeta desde Unity Hub utilizando:

text Unity 6 

---

## 🖥️ Motor de Desarrollo

- Unity 6

## 👨‍💻 Autor

Hansel Andre López Montenegro

---

## 🎮 Gameplay

Haz click a continuación para visualizar gameplay en YouTube.

[![Trapped Inside Gameplay](https://img.youtube.com/vi/mPIO5fUtbHQ/maxresdefault.jpg)](https://youtu.be/mPIO5fUtbHQ)