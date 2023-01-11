<template>
    <div>
        <h2>Manage Goals</h2>
        <input type="text" ref="goal">
        <button @click="setGoal">Set Goal</button>
        <teleport to="body">
            <error-alert v-if="invalidData">
                <h2>Input is invalid</h2>
                <p>Please enter at least a few characters...</p>
                <button @click="confirmError">Okay</button>
            </error-alert>
        </teleport>
    </div>
</template>

<script>
import ErrorAlert from "./ErrorAlert.vue"
export default {
    components: {
        ErrorAlert
    },
    data() {
        return {
            invalidData: false
        }
    },
    methods: {
        setGoal() {
            const enteredGoal = this.$refs.goal.value;
            if (enteredGoal === "") {
                this.invalidData = true;
            }
        },
        confirmError() {
            this.invalidData = false;
        }
    }
}
</script>