<template>
  <ul>
    <li><h2>{{ userName }}  age:  {{ userAge }}</h2></li>
    
  </ul>
</template>

<script>
export default {
  props:{
    userName:{
        type: String,
        required: true
    },
    userAge:{
        type: Number,
        required: true
    }
  },
};
</script>
