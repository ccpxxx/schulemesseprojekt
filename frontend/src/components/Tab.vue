<template>
    <div class="wrapper-container" v-if="title == selectedTitle">
      <slot></slot>
    </div>
  </template>
  <script setup lang="ts">
  import { inject } from 'vue';
    // export default {
    //   props: {
    //     title: {
    //       type: String,
    //       default: 'Tab'
    //     }
    //   },
    //   data () {
    //     return {
    //       isActive: true2
    //     }
    //   }
    // }
    const { title = "Tab" } = defineProps<{ title?: string }>()
    const isActive = $ref(true)
    const selectedTitle= inject('selectedTitle')
    console.log(selectedTitle)
  </script>
<style scoped>

  .wrapper-container {
    aspect-ratio: 1/1;
    padding: 1rem;
    width: minmax(20rem, 50rem);
     background: rgba(0,0,0,0.1);
    margin: 5rem auto;
  }
  
</style>