<template >
  <div class="wrapper--container border-2 border-red-200">
    <div class="wrapper_container" :class='{"tabs__light": mode === "light", "tabs__dark": mode === "dark"}'>
      <ul class='tabs__header'>
        <li v-for='title in tabTitles'
        :key="title"
        class=""
        :class="{selected: title === selectedTitle, confirm: title === '4', register: title === '1', contact: title === '2', picture: title === '3'}"
        @click="selectedTitle=title"
        >
            {{title}}
        </li>
      </ul>
      <slot class="p-4" />
    </div>
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
      display: flex;
      justify-content: center;
      gap: 4rem;
      list-style: none;
      margin: 0 0 0 20px;
      padding: 0;
    }
    ul.tabs__header > li {
      padding: 10px 19px;
      border-radius: 100%;
      margin: 0;
      font-size: 20px;
      display: inline-block;
      margin-right: 5px;
      cursor: pointer;
      width: 50px;
      height: 50px;
      border: 2px solid rgba(0, 0, 0, 0.563);
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
        // border-radius: 10px;
       border: 2px solid rgb(255, 8, 177) !important;
        background-color: lightblue !important;
        color: black!important;
    }

    .confirm {
      pointer-events: none;
    }

    .tabs__header > :not(:last-child)::after {
      content: '';
      position: absolute;
      top: 50%;
      right: -55px;
      width: 40px;
      height: 2px;
      background: rgba(26, 28, 29, 0.831);
      transition: width .3s;
    }
    .tabs__header > li {
      position: relative;
    }
  </style>