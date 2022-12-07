<template >
    <div class="wrapper_container" :class='{"tabs__light": mode === "light", "tabs__dark": mode === "dark"}'>
      <ul class='tabs__header'>
        <li v-for='title in tabTitles'
        :key="title"
        :class="{selected: title === selectedTitle}"
        @click="selectedTitle=title"
        >
            {{title}}
        </li>
      </ul>
      <slot class="p-4" />
    </div>
  </template>
  
  <script  lang="ts">

import { SlotFlags } from '@vue/shared';
import { onMounted } from 'vue';
import { ref, provide, useSlots } from "vue";

export default {
    props: {
        mode: {
            type: String,
            default: 'dark'
        }
    },
    setup(props, {slots }) {
        console.log(slots, "SLOTS")
        const tabTitles = ref(slots.default!().map((tab) => tab.props!.title))
        const selectedTitle = ref(tabTitles.value[0])
        provide('selectedTitle', selectedTitle)
        return {
            tabTitles,
            selectedTitle
        }
    }
}
  </script>
  
  <style lang="scss">
//   .wrapper-container {
//     height: 200px;
//     width: 200px;
//     // background: white;
//     margin: 0 auto;
//   }
    ul.tabs__header {
      display: block;
      list-style: none;
      margin: 0 0 0 20px;
      padding: 0;
    }
    ul.tabs__header > li {
      padding: 15px 30px;
      border-radius: 10px;
      margin: 0;
      display: inline-block;
      margin-right: 5px;
      cursor: pointer;
    }
    ul.tabs__header > li.tab__selected {
      font-weight: bold;
      border-radius: 10px 10px 0 0;
      border-bottom: 8px solid transparent;
    }
    .tab {
      display: inline-block;
      color: black;
      padding: 20px;
      min-width: 800px;
      border-radius: 10px;
      min-height: 400px;
    }
    .tabs__light .tab{
      background-color: #fff;
    }
    .tabs__light li {
      background-color: #ddd;
      color: #aaa;
    }
    .tabs__light li.tab__selected {
      background-color: #fff;
      color: #83FFB3;
    }
    .tabs__dark .tab{
      background-color: #555;
      color: #eee;
    }
    .tabs__dark li {
      background-color: #ddd;
      color: #aaa;
    }
    .tabs__dark li.tab__selected {
      background-color: #555;
      color: white;
    }
    .selected {
        border-radius: 10px;
       border: 1px solid black;
        background-color: lightblue !important;
        color: black!important;
    }
  </style>