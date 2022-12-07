# Landing Page Template

Eine Vite & Vue 3 Template für Landing Pages

## Features

### i18n - Internationalisierung
[Dokumentation](https://kazupon.github.io/vue-i18n/)
Erlaubt es Texte per JSON zu defineren und ändern. Ist auch beim arbeiten mit nur einer Sprache nützlich, da alle Texte zentral gespeichert sind, nicht den Code voll stopfen und per CSV im- & export von nicht-Programmierern in Excel bearbeitet werden können.

### vue router - Routing
[Dokumentation](https://router.vuejs.org/)
Erlaubt die Arbeit mit Routing und URL Parameter/Querys

### vueuse/head
[Dokumentation](https://github.com/vueuse/head#usage)
Erlaubt es den HTML head innerhalb von vue-Files zu modifizieren

### vite-ssg
[Dokumentation](https://github.com/vueuse/head#usage)
Statisches Seiten-Rendering bedeutet dass unsere Seite - soweit wie möglich - nicht als SPA sondern als statisches HTML gerendert wird. Verwende dazu den npm-Befehl "build-ssg"

### vite-imagetools
[Dokumentation](https://github.com/JonasKruckenberg/imagetools/tree/main/packages/vite)
Bilder können in vite schon standardmäßig per JavaScript-Imports importiert werden. Dieses Plugin ermöglich es, Argumente an den Pfad anzuhängen um diese Bilder zu transformieren.
`import image from "example.png?h=102;1024&format=webp;avfi;png"` generiert 6 indiviuelle Bilder als string-Array: .webp, .avfi und .png mit Höhe 102px und automatischer Breite, .webp, .avfi und .png mit Höhe 1024px und automatischer Breite

### unplugin-vue-components
Components werden automatisch global gemountet und im build-prozess tree-shaked, ein manuelles Component-importieren vom components in `src/components` innerhalb von vue-files ist nicht mehr notwendig. Hierzu wird die Datei components.d.ts automatisch aktualisiert, diese bitte comitten und nicht manuell bearbeiten.



## Hinweise - übernommen aus der originalen vue3 readme

### Recommended IDE Setup

- [VS Code](https://code.visualstudio.com/) + [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar)

### Type Support For `.vue` Imports in TS

Since TypeScript cannot handle type information for `.vue` imports, they are shimmed to be a generic Vue component type by default. In most cases this is fine if you don't really care about component prop types outside of templates. However, if you wish to get actual prop types in `.vue` imports (for example to get props validation when using manual `h(...)` calls), you can enable Volar's Take Over mode by following these steps:

1. Run `Extensions: Show Built-in Extensions` from VS Code's command palette, look for `TypeScript and JavaScript Language Features`, then right click and select `Disable (Workspace)`. By default, Take Over mode will enable itself if the default TypeScript extension is disabled.
2. Reload the VS Code window by running `Developer: Reload Window` from the command palette.

You can learn more about Take Over mode [here](https://github.com/johnsoncodehk/volar/discussions/471).
