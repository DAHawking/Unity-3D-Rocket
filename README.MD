# 1 项目介绍（中文）
本项目为本科毕业设计源代码，《基于Unity 3D的运载火箭飞行实时视景仿真》
## 1.1 摘    要
近年来，随着国内外航空航天技术研究的快速发展，对运载火箭飞行的仿真要求也越来越高，通过计算机建模仿真已经成为航空航天领域重要的发展方向。本文针对运载火箭飞行的视景仿真需求，基于主流的视景仿真引擎Unity 3D，设计了运载火箭的实时仿真系统，为运载火箭的设计和制导控制系统的研究提供技术支持。本视景仿真系统首先设计数据通信获取运载火箭的飞行数据，在Unity 3D中驱动运载火箭模型。然后搭建完整的视景仿真系统，分为静态场景、动态效果、逻辑运算、人机交互四个模块。

综上所述，本论文主要完成了以下工作：

（1）首先对视景仿真国内外研究现状进行了调研分析，概述三维建模技术，对比主流的三维建模软件优缺点，然后比较了主流的视景仿真开发游戏引擎，最后决定选用性能优良的3DS MAX和Unity 3D进行视景仿真系统的开发。

（2）从总体架构上分析了视景仿真系统需要实现的各个模块，详细介绍了各个模块将会实现的功能，描述了运载火箭飞行过程中将经历的场景。

（3）对Unity 3D游戏引擎的物理引擎、粒子系统和碰撞检测系统等进行了分析，设计了半实物仿真系统与视景仿真系统的数据通信。利用飞行数据成功驱动火箭模型，并绘制飞行轨迹。设计了系统的人机交互模块，主要有GUI信息的显示和键盘、鼠标的控制。

（4）利用3DS MAX创建火箭和火箭发射台模型，设定天空盒和太阳光，创建真实的地面场景，添加尾焰效果和多级火箭分离等技术。

## 1.2 关键词
运载火箭，视景仿真，Unity 3D，3DS MAX，模块化，人机交互。



# 2 Project Introduction（English）
The project is the source code of undergraduate graduation design, "Real Time Visual Simulation of Carrier Rocket Flight Based on Unity 3D"
## 2.1 ABSTRACT
In recent years, with the development of aerospace in China and foreign countries. There are more requirements for the simulation of carrier rocket flight. The importance of computer modeling and simulation has increased for aerospace research. Based on the mainstream visual simulation engine Unity 3D, this paper designs the real-time simulation system of carrier rocket and supports the design of carrier rocket and guidance system. The visual system obtains the flight data of the carrier rocket and drives the carrier rocket model in unity 3D. Then build a complete visual simulation system, which is divided into four parts: static scene, dynamic effect, logical operation and human-computer interaction.

In conclusion, this paper mainly completes the following work:

(1) Analyzing the research situation of visual simulation in China and foreign countries, introduces 3D modeling technology, comparing the mainstream 3D modeling software, then comparing the mainstream visual simulation game engines, and finally selecting 3DS MAX and Unity 3D to establish the visual simulation system.

(2) Analyzing each part of the visual simulation system, introducing the functions that each module will realize, and describing the scenes that the carrier rocket will experience in the flight process.

(3) Analyzing the physics engine, particle system and collision detection system of unity 3D game engine, designing the data connection between hardware in the loop simulation system and visual simulation system, using flight data to drive the rocket model and draw the flight trajectory, and designing human-computer interaction, mainly including the display of GUI information and the control of keyboard and mouse.

(4) Using 3DS MAX to create rocket model and rocket launch platform model, setting Skybox and sunlight, creating real ground scene, adding tail flame and multi-stage rocket separation.
## 2.2 Keywords
Carrier Rocket, Visual Simulation, Unity 3D, 3DS MAX, Modular, Human-Computer Interaction.