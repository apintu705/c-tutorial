<template>
  <form @submit.prevent="addUser">
    <div>
      <label>Name</label>
      <input type="text" v-model="enteredName" required />
    </div>
    <div>
      <label>age</label>
      <input type="number" v-model="enteredAge" required />
    </div>
    <div>
      <button>Add User</button>
    </div>
  </form>
  <!-- <active-user v-if="show" :userName="enteredName" :age="enteredAge"></active-user> -->
</template>

<script>
export default {
  emits: ["add-user"],
  data() {
    return {
      enteredName: "",
      enteredAge: "",
      show: false,
    };
  },
  methods: {
    addUser() {
      this.$emit("add-user", this.enteredName, this.enteredAge);
    },
  },
};
</script>
