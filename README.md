・[English](README.en.md) ・[中文](README.md) ・[日本語](README.jp.md)

[![GitHub downloads](https://img.shields.io/github/downloads/genshin-matrix/genshin-fishing-toy/total)](https://github.com/emako/genshin-fishing-toy/releases)
[![GitHub downloads](https://img.shields.io/github/downloads/genshin-matrix/genshin-fishing-toy/latest/total)](https://github.com/emako/genshin-fishing-toy/releases)

# 🐟原神钓鱼姬

> Genshin Fishing Toy [（原始仓库）](https://github.com/babalae/genshin-fishing-toy)

PC原神自动钓鱼机（支持不同游戏窗口大小）。

『你只需负责甩竿，后面的放着我来！』

操作最简单的自动钓鱼机，选钓鱼框后启动钓鱼，简单易用，解放双手。

- [x] 采用视觉识别。
- [x] 鱼儿上钩后延迟0~1s自动提竿。

## 程序界面

<img src="/src/GenshinFishingToy/Resources/demo.gif" style="zoom:100%;border 0px solid white;border-radius:10px" />

![](assets/image1.zh.png)

![](assets/image2.zh.png)

## 使用方法

<img src="src/GenshinFishingToy/Resources/demo.png" alt="demo" style="zoom:80%;border 0px solid white;border-radius:10px" />

1. 首先移动半透明矩形钓鱼框选择识别范围，钓鱼框可调整大小，只需要框住钓鱼进度条就可以了，<font color='red'> 不要框住下方的钓鱼总进度圈 </font>。

2. 确认选框位置正确后，就直接启动进行自动钓鱼啦（快捷键<kbd>F11</kbd>）。

> - 甩竿后直接等待鱼儿上钩即可，程序会自动根据当前图像识别的结果发送对应鼠标操作，自动化提竿、完成钓鱼进度。
>
> - 如果无法正常自动模拟按键，请尝试将本程序添加至杀软白名单，或关闭杀软后使用。

## 常见问题
- 如果不在钓鱼的时候最好还是停止钓鱼功能。
- 无法自动提竿的话请尝试调高条框的高度。
  
- 若安装包无法安装，请确保你的系统已安装应用商店，安装包依赖商店架构 (MSIX)。

- 运行环境是net6.0-windows10.0.18362.0。

- 独占模式建议全程使用窗口模式使用（游戏内快捷键<kbd>Alt</kbd>+<kbd>Enter</kbd>）。

  - 独占模式下的可正常操作流程：

  > - 启动游戏进程->启动钓鱼姬->退出钓鱼姬->退出游戏进程

  - 独占模式下存在问题的流程：

  > - 启动钓鱼姬->启动游戏进程->退出钓鱼姬->退出游戏进程（无法恢复钓鱼框位置并变成类似-30000多的值）
  >
  > - 启动游戏进程->启动钓鱼姬->退出游戏进程->退出钓鱼姬（游戏退出瞬间可能会误识别为窗口模式）

