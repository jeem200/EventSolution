<template>
  <v-container>
    <v-row>

      <v-col>
          <v-text-field
            label="Vendor Name"
            value="Vendor Name"
            v-model="vendor.VendorName"
            outlined
          >
          </v-text-field>
      </v-col>    
      <v-col>
          <v-text-field
            label="Number Of Collaboration"
            value="0"
            v-model="vendor.NoOfCollab"
            outlined
          >
          </v-text-field>
      </v-col>

    </v-row>
    <v-row>
      <v-col>
          <v-app-bar
            color="grey lighten-4 black--text"
            dense
            dark
            elevation="0"
          >
            <v-toolbar-title>Services</v-toolbar-title>
            <v-spacer></v-spacer>
                <v-btn
                small
                fab
                icon
                @click="openModal"
              >
               <v-icon color="black" dark> add_circle</v-icon>
              </v-btn>

          </v-app-bar>
            <v-simple-table
            
            >
              <template v-slot:default>
                <thead>
                  <tr>
                    <th class="text-left">
                      Code
                    </th>
                    <th class="text-left">
                      Name
                    </th>
                     <th class="text-left">
                      Type
                    </th>
                    <th class="text-left">
                      Price
                    </th>
                     <th class="text-left">
                      Min Guest
                    </th>
                    <th class="text-left">
                      Max Guest
                    </th>
                  </tr>
                </thead>
                <tbody >
                  <template
                    v-if="vendor.serviceType.length>0"
                  >
                    <tr
                      
                      v-for="(item,index) in vendor.serviceType"
                      :key="index"
                    >
                      <td class="text-left" >{{ item.ItemCode }}</td>
                      <td class="text-left" >{{ item.ItemName }}</td>
                      <td class="text-left" >{{ item.ItemType }}</td>
                      <td class="text-left" >{{ item.ItemPrice }}</td>
                      <td class="text-left" >{{ item.MinGuest }}</td>
                      <td class="text-left" >{{ item.MaxGuest }}</td>
                    </tr>
                  </template>
                  <template v-else>
                    <tr>
                      <td colspan="6">No Data</td>
                    </tr>
                  </template>
                </tbody>
           
              </template>
            </v-simple-table>
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
    <v-dialog
      width="1200"
      v-model="dialog"
      fullscreen
      
      transition="dialog-bottom-transition"
    >
      <ServiceAddForm 
        :count="vendor.serviceType.length"
        @save="saveService"
        @close="closeModal"
      />
    </v-dialog>
  </v-container>
</template>

<script>


import ServiceAddForm from './ServiceAddForm.vue'
import axios from 'axios'
  export default {
    components:{ ServiceAddForm },
    data () {
      return {
        dialog: false,
        notifications: false,
        sound: true,
        widgets: false,
       
        vendor:{
          VendorName:'Vendor Name',
          NoOfCollab:0,
          serviceType: [],
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
