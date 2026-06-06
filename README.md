# 🏚️ Trapped Inside

**Trapped Inside** es un juego de terror psicológico tipo *escape room* desarrollado en **Unity**.  
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

---

## 📥 Clonar el Proyecto

Este proyecto utiliza **Git LFS (Large File Storage)** para almacenar modelos, animaciones y otros archivos de gran tamaño.

### 1. Instalar Git LFS

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

```bash
git lfs pull
```

o

```bash
git lfs fetch --all
git lfs checkout
```

### 5. Abrir el proyecto

Abrir la carpeta desde Unity Hub utilizando:

```text
Unity 6
```

---

## 🖥️ Motor de Desarrollo

- Unity 6

## 👨‍💻 Autor

Hansel Andre López Montenegro

---

## 🎮 Gameplay
Haz click a continuación para visualizar gameplay en youtube.
[![Trapped Inside Gameplay](https://img.youtube.com/vi/BTnM5AmLtzM/maxresdefault.jpg)](https://youtu.be/BTnM5AmLtzM)