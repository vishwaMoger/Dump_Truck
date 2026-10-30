<p align="center">
  <img width="100%" src="https://capsule-render.vercel.app/api?type=rect&color=0:FFB000,50:FFD54F,100:FFB000&height=200&section=header&text=%F0%9F%9A%9A%20DUMP%20TRUCK&fontSize=72&fontColor=1a1a1a&fontAlignY=45&stroke=000000&strokeWidth=2&desc=CLEAN%20UP%20THE%20CITY%20BEFORE%20THE%20CLOCK%20RUNS%20OUT&descSize=20&descAlignY=75&animation=fadeIn" alt="Dump Truck" />
</p>

<p align="center">
  <img src="https://readme-typing-svg.demolab.com?font=Black+Ops+One&size=26&duration=2400&pause=600&color=FFB000&center=true&vCenter=true&width=700&lines=3...+2...+1...+GO!+%F0%9F%9A%A6;%F0%9F%9A%9A+Drive+the+garbage+truck;%F0%9F%97%91%EF%B8%8F+Pick+up+the+trash;%F0%9F%93%A6+Deposit+it+at+the+bins;%F0%9F%8F%86+Clean+city+%3D+high+score!" alt="tagline" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-2022.3-000000?style=for-the-badge&logo=unity&logoColor=white" />
  <img src="https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Physics-Wheel%20Colliders-FFB000?style=for-the-badge&logoColor=black" />
  <img src="https://img.shields.io/badge/Camera-Cinemachine-1a1a1a?style=for-the-badge&logo=unity&logoColor=FFB000" />
  <img src="https://img.shields.io/badge/Genre-3D%20Driving-FF6F00?style=for-the-badge" />
</p>

---

<h2 align="center">🏙️ THE JOB</h2>

<p align="center">
You're the city's garbage truck driver. 🚚<br/>
Wait for the <b>countdown</b>, then hit the road through a <b>low-poly city</b>,<br/>
stop at each <b>trash pickup point</b>, load up, and haul it all to the <b>dumpster bins</b>.<br/>
Your pickups and deposits are tallied on the <b>finish screen</b>.
</p>

---

<h2 align="center">🔁 GAMEPLAY LOOP</h2>

```mermaid
flowchart LR
    A(["🚦 3-2-1<br/>Countdown"]):::y --> B["🚚 Drive<br/>through the city"]:::k
    B --> C["🗑️ Reach a<br/>pickup point"]:::y
    C --> D["👆 PICK UP<br/>button appears"]:::o
    D --> E["📦 Trash collected<br/>counter +1"]:::y
    E --> F{"More<br/>trash?"}:::k
    F -- yes --> B
    F -- no --> G["♻️ Deposit at<br/>dumpster bins"]:::o
    G --> H(["🏆 Finish screen<br/>picked up · deposited"]):::y
    classDef y fill:#FFB000,color:#000,stroke:#000
    classDef k fill:#1a1a1a,color:#FFB000,stroke:#FFB000
    classDef o fill:#FF6F00,color:#fff,stroke:#000
```

---

<p align="center">
  <img width="100%" src="docs/readme/features.svg" alt="Truck specs: wheel physics, Cinemachine, engine audio, pickup FX, countdown, live HUD" />
</p>

---

<h2 align="center">🎮 CONTROLS</h2>

<table align="center">
<tr><th>Action</th><th>Keys</th></tr>
<tr><td>⬆️ Accelerate / ⬇️ Reverse</td><td><kbd>W</kbd> <kbd>S</kbd> / <kbd>↑</kbd> <kbd>↓</kbd></td></tr>
<tr><td>↔️ Steer</td><td><kbd>A</kbd> <kbd>D</kbd> / <kbd>←</kbd> <kbd>→</kbd></td></tr>
<tr><td>🛑 Brake</td><td><kbd>B</kbd></td></tr>
<tr><td>🗑️ Pick up trash</td><td>On-screen <b>PICK UP</b> button</td></tr>
</table>

---

<h2 align="center">🧠 UNDER THE HOOD</h2>

| Script | Role |
|:--|:--|
| `PlayerController.cs` | 🚚 Wheel colliders, engine force, braking, steering, pickup/deposit logic, HUD and finish screen |
| `TimerScrip.cs` | 🚦 Start countdown that locks the engine until "GO" |
| `MyCarSound.cs` | 🔊 Engine audio pitch control |

---

<h2 align="center">🚀 RUN IT</h2>

```bash
git clone https://github.com/vishwaMoger/Dump_Truck.git
```

1. Open the folder in **Unity 2022.3**.
2. Open `Assets/Scenes/SampleScene.unity`.
3. Press ▶️ **Play**.

---

<p align="center">
  <b>Made with ❤️ and 🚚 by <a href="https://github.com/vishwaMoger">Vishwa Moger</a></b><br/>
  <sub>Game Developer · 3+ years · Bangalore, India</sub>
</p>

<img width="100%" src="https://capsule-render.vercel.app/api?type=rect&color=0:FFB000,50:1a1a1a,100:FFB000&height=20&section=footer" />
