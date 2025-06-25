import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue-jsx'
import vueDevTools from 'vite-plugin-vue-devtools'
import fable from 'vite-plugin-fable'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    fable({
      fsproj: './src/Fable.Vue.fsproj',
      jsx: 'preserve', // Use 'preserve' to keep JSX syntax for Vue
    }),
    vueJsx({
      include: [ /\.fs$/], //
    }),
    vue({
      
    }),
    vueDevTools(),
  ],
  // assetsInclude: [
  //   '**/*.fs',
  // ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    },
  },
})
