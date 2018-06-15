# BadEggSTudio! Unity Package #
---
Helper methods and little tools setup on top of Unity3D written in C# language.

This is repo aims for internal use within BadEggSTudio! at this moment, and it is also for my personal profile.

---
# Features #
BadEggSTudio! Unity Package provides many helpful methods for developers who are using Unity3D for their project. Here is the list of those features:

1. Preset API core (handling REST call between frontend and backend)
2. Localization (WIP, can use in this stage, but the performance need to improve)
3. Local Save/Load (included encode handling, such as AES encryption)
4. Common Helper methods (message logger, local/global transform edit methods)
5. SerializableDictionary
6. uYoutubeLoader (WIP, at this moment, it cannot decrypt encrypted videos)

---
# Core Files #
These files will be updated from BadEggSTudio!UnityPackage Repo, which aims at the reusable code and reduces common implementation.
Developers should avoid changing these files so as to maintain smooth upgrade for each project.
[PROJECT_ROOT]/Assets/...

* **/BadEggStudio Package/BadEggStudio/Core/:** API core
* **/BadEggStudio Package/BadEggStudio/Localization/:** Localization Core
* **/BadEggStudio Package/BadEggStudio/Security/:** Encryption Core
* **/BadEggStudio Package/BadEggStudio/Utils/:** Other helper methods and tools, such as common helper and SerializableDictionary...
* **/BadEggStudio Package/BadEggStudio/uYoutubeLoader/:** uYoutube Core
* **/BadEggStudio Package/Demos/:** All demos with scripts for this package

---
# Setup #

1. Download the latest BadEggSTudio!UnityPackage from **Release** page
2. Open Unity
3. Import the custom BadEggSTudio!UnityPackage to your project

---
# Contribute #

If you want to constribute this project, please send an email to [info@badeggstudio.com]("mailto:info@badeggstudio.com").