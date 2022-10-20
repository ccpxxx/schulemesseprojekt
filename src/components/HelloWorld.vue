<template>
  <h1>{{ msg }}</h1>

  <p>
    Recommended IDE setup:
    <a href="https://code.visualstudio.com/" target="_blank">VS Code</a>
    +
    <a href="https://github.com/johnsoncodehk/volar" target="_blank">Volar</a>
  </p>

  <p>See <code>README.md</code> for more information.</p>

  <p>
    <a href="https://vitejs.dev/guide/features.html" target="_blank">
      Vite Docs
    </a>
    |
    <a href="https://v3.vuejs.org/" target="_blank">Vue 3 Docs</a>
  </p>

  <button class="py-2 px-6 my-4 border rounded text-black border-green-900 hover:text-green-900 hover:bg-green-400 transition" @click="count++">
    count is: {{ count }}
  </button>
  <p>
    Edit
    <code>components/HelloWorld.vue</code> to test hot module replacement.
  </p>
</template>

<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const { msg = "" } = defineProps<{ msg?: string }>()

const count = $ref(0)
</script>