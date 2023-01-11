<template>
    <div class="nav">
      <router-link to="/">{{ $t('messe.home') }}</router-link>
    </div>
    <section class="user-list w-full justify-center items-center flex flex-col gap-2">
      <div class="w-full justify-center items-center flex flex-col gap-2" >
        
        <div class="user flex flex-row gap-4 hover:bg-red-200 hover:cursor-pointer"  @click="print(user)" v-for="user in users" :key="user.id">
        <p>{{ user.id }}</p>
        <p>{{ user.firstname + " " +  user.name }}</p>

      </div>
      <button @click="getCompanies">{{ $t('messe.getCompanies') }}</button>
      <div v-if="companies" class="flex gap-3 flex-col">
        <div v-for="company in companies">
          <p>{{ company }}</p>
        </div>
      </div>
      </div>


    </section>
    <dialog class="w-full" ref="dialogPopUp" >
      <!-- <div class="dialog-container flex flex-col print">
        <p> {{ activeUserName }}</p>
        <img :src="activePicture">
        
      </div>
      <button @click="printUser">Print</button> -->

      <div class="card-container print border gap-2 pl-4 border-cyan-200 grid grid-cols-2" v-if="activeUser" >
        <div class="card-container__left flex p-4 justify-center rounded-full ">
            
                <img :src="userMain.picture"
                class="moveIn h-[429px] w-[429px] object-cover rounded-full" alt="user picture " />
           
        </div>
        <div class="card-container__right p-4">
            <div class="card-container__right__text border h-full border-gray-800 rounded-sm">
                <h1 class="h-20 text-4xl">{{$t("messe.prename")}} {{ userMain.firstname }}</h1>
                <h2 class="h-20 text-4xl">{{$t("messe.name")}} {{ userMain.name}}</h2>
                <h2 v-if="userMain.company" class="h-20 text-4xl">{{$t("messe.company")}} {{ userMain.company }}</h2>
                <h2 v-if="userMain.interests" class="h-20 w-20 text-4xl">{{ $t("messe.interest") }} {{userMain.interests.map(val => {
                    return val
                }).join(", ") }} </h2>
            </div>
    </div>
</div>
<button @click="printUser">{{ $t('messe.print') }}</button>
    </dialog>
    <!-- <HelloWorld :msg="$t('headline')" /> -->
  </template>
  
  <script setup lang="ts">
  // @ts-ignore
  import logo from "./assets/logo.png?h=100;200&format=webp;avfi;png"
  import UserObject from "../interfaces/UserObject";
  import axios from "axios"
  import {onMounted} from "vue"
  const hidden= $ref(false)
  let users: UserObject[] = $ref([])
  let userMain: UserObject = $ref({})
  
    axios.get("https://localhost:13377/api/messe/getUsers").then((resp) => {
    users = resp.data
    console.log(users, "USERS")
    
  })
  
  
 let companies = $ref([])
 function getCompanies () {
   axios.get("https://localhost:13377/api/messe/getCompanyCustomers").then((resp) => {
    companies = resp.data.map((val: any, index: number) => {
      return index + " " + val.company
    })
    console.log(companies, "COMPANIES")
  })
  }
  function print(user: UserObject) {
    // for (user in users) {
    //   user.picture.replaceAll("\n","")
    // }
    userMain = user
    activeUser = true
    console.log(userMain, "USERMAIN")
    
    // activeUserName = user.firstname
    // console.log(userMain, "USER PRINT")
    // activePicture = user.picture
    // activelastName = user.name
    dialogPopUp!.showModal()

  }
  function printUser() {
    window.print()
    activeUser = false
  }
  let activeUserName = $ref("")
  let activelastName = $ref("")
  let isOfficial = $ref(false)
  let activePicture = $ref("")
  let activeUser = $ref(false)
  const dialogPopUp = $ref(null)
  function imgLoaded(ev: Event) { (ev.target as HTMLImageElement).style.opacity = '100' }

  function sendUserData(users: UserObject[]) {
    console.log(users)

  }
  </script>

  <style scoped>
  @media print {
  body:not(.print) {
    display: none;
  }
}
  </style>