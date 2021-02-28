<template>

      <v-container>
    <v-row>

      <v-col>
          <v-text-field
            label="Name"
            value="Name"
            v-model="customer.Name"
            outlined
          >
          </v-text-field>
      </v-col>    
      <v-col>
          <v-text-field
            label="Age"
            value="0"
            v-model="customer.Age"
            outlined
          >
          </v-text-field>
      </v-col>

    </v-row>
    <v-row>

      <v-col>
          <v-text-field
            label="Email"
            value="example@example.com"
            v-model="customer.Email"
            outlined
          >
          </v-text-field>
      </v-col>    
      <v-col>
          <v-text-field
            label="Phone"
            value="01XXXXXXXXXXX"
            v-model="customer.Phone"
            outlined
          >
          </v-text-field>
      </v-col>

    </v-row>
    <v-row>

      <v-col
      >
        <v-color-picker v-model="customer.Color"></v-color-picker>
      </v-col>
    </v-row>

    <v-row>
        <v-btn
          dark
          color="primary"
          text
          @click="save"
        >
              Save
        </v-btn>
        {{vendor}}
    </v-row>

  </v-container>

</template>

<script>



import axios from 'axios'
  export default {

    data () {
      return {
        dialog: false,
        notifications: false,
        sound: true,
        widgets: false,
       
        customer:{
          Name:'Name',
          Age:0,
          Email:'example@example.com',
          Phone:'01XXXXXXXXXXX',
          Color:'',
        }
      }
    },
    methods:{
      openModal:function(){
        this.dialog=true
      },
      closeModal:function(){
        this.dialog=false
      },
      saveService:function(service){
        console.log("WERE",service)
          let item={
            
            ItemCode:service.ItemCode,
            ItemName:service.ItemName,
            ItemType:service.ItemType,
            ItemPrice:parseInt(service.ItemPrice),
            MinGuest:parseInt(service.MinGuest),
            MaxGuest:parseInt(service.MaxGuest),
            ItemDescription:service.ItemDescription

          }
        this.vendor.serviceType.push(item)
      },
      save:async function(){
        //this.vendor.ServiceType=this.serviceType
        this.vendor.NoOfCollab=parseInt(this.vendor.NoOfCollab)
        const res= await axios.post('https://localhost:44327/api/vendor', this.vendor);
        console.log("RESPONSE",res)
      }
    }
  }
</script>
