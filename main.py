import PySimpleGUI as sg
import urllib
import zipfile
import os

#urllib.urlretrieve("http://www.example.com/songs/mp3.mp3", "mp3.mp3")

layout = [
[sg.Text("select game folder: "), sg.Input(), sg.FolderBrowse()],
[sg.Text("                              ^this should be the same folder as the exe for the game^")],
[sg.Text("install bepinex"), sg.Button("download")],
[sg.Text("bepinex only has to be downloaded once")],
[sg.Text("")],
[sg.Text("mods, checked = enabled")],
[sg.Checkbox("enable cheats")],
[sg.Checkbox("remove promotion per floor limit")],
[sg.Checkbox("disable sleep")],
[sg.Button("confirm")]

          ]


window = sg.Window('SITTSM mod manager', layout, finalize=True)

while True:

    event, values = window.read()

    if event == "download":
        urllib.request.urlretrieve("https://uniquename.pythonanywhere.com/static/stick-man-files/sittsm-bepinex.zip", "bepinex.zip")
        with zipfile.ZipFile("bepinex.zip", 'r') as zip_ref:
            zip_ref.extractall(values["Browse"])
    if event == sg.WIN_CLOSED or event == 'Cancel':
        break

    def sus(x, modName, modUrl):
        if values[x] == True:
            urllib.request.urlretrieve(
                modUrl,
                f"{values['Browse']}/BepInEx/plugins/{modName}.dll")
        if values[x] == False and os.path.exists(f"{values['Browse']}/BepInEx/plugins/{modName}.dll"):
            os.remove(f"{values['Browse']}/BepInEx/plugins/{modName}.dll")


    sus(1, "enable-cheats", "https://github.com/UniqueName0/SITTSM_enable-cheats-mod/raw/main/enable-cheats.dll")
    sus(2, "remove-promotions-limit", "https://github.com/UniqueName0/SITTSM_remove-promotions-per-floor-limit-mod/raw/main/remove-promotions-limit.dll")
    sus(3, "remove-sleep-effect", "https://github.com/UniqueName0/SITTSM_remove-promotions-per-floor-limit-mod/raw/main/remove-promotions-limit.dll")
window.Close()
