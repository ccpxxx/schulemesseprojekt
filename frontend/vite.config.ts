import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import Components from 'unplugin-vue-components/vite'
import { imagetools } from 'vite-imagetools'

export default defineConfig({
  plugins: [
    vue({ reactivityTransform: true }),
    Components({ dts: true }),
    imagetools(),
  ],
  // "script: 'async'" entfernen wenn script synchron geladen werden soll
  // @ts-ignore
  ssgOptions: { script: 'async', dirStyle: 'nested' },
})