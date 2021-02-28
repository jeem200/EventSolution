<template>
  <v-row justify="center">
  
      <v-card>
        <v-toolbar
          dark
          color="primary"
        >
          <v-btn
            icon
            dark
            @click="close"
          >
            <v-icon>mdi-close</v-icon>
          </v-btn>
          <v-toolbar-title>Settings</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-toolbar-items>
            <v-btn
              dark
              text
              @click="save"
            >
              Save
            </v-btn>
          </v-toolbar-items>
        </v-toolbar>


   
        <v-container>
            <v-row>

                <v-col>
                   <v-select
                       
                        :items="items"
                        item-text="text"
                        item-value="value"
                        label="Select Aspect"
                        v-model="serviceDetails.ItemType"
                      
                        outlined
                    >
                    
                    </v-select>
                </v-col>    
           

            </v-row>

            <v-row>

                <v-col>
                    <v-text-field
                        label="Item Name"
                        value="Item Name"
                        v-model="serviceDetails.ItemName"
                        outlined
                    >
                    </v-text-field>
                </v-col>    
                <v-col>
                    <v-text-field
                        label="Item Price"
                        value="0"
                        v-model="serviceDetails.ItemPrice"
                        outlined
                    >
                    </v-text-field>
                </v-col>

            </v-row>
  
            <v-row>

                <v-col>
                    <v-text-field
                        label="Min Guest"
                        value="0"
                        v-model="serviceDetails.MinGuest"
                        outlined
                    >
                    </v-text-field>
                </v-col>    
                <v-col>
                    <v-text-field
                        label="Max Guest"
                        value="0"
                        v-model="serviceDetails.MaxGuest"
                        outlined
                    >
                    </v-text-field>
                </v-col>

            </v-row>
            <v-row>

                <v-col>
                    <v-textarea
                        outlined
                        v-model="serviceDetails.ItemDescription"
                      
                        label="Description"
                        value=""
                    >
                    </v-textarea>
                </v-col>    
           

            </v-row>


        </v-container>

      </v-card>
    
  </v-row>
</template>

<script>
  export default {
    props:['count'],
    data () {
      return {
        dialog: false,
        notifications: false,
        sound: true,
        widgets: false,
        items:[{ text:'Food',value:'food'},
               { text:'Decoration',value:'decoration'},
               { text:'Venue',value:'venue' },
               { text:'Photography',value:'photography'}
              ],
        serviceDetails:{
     
          ItemName:'Item Name',
          ItemType:'Select Aspect',
          ItemPrice:0,
          MinGuest:0,
          MaxGuest:0,
          ItemDescription:'Description'
        }
      }
    },
    methods:{
        close:function(){
            this.$emit("close")
        },
        save:function(){

          this.serviceDetails.ItemCode=this.generateCode
          this.$emit("save",this.serviceDetails)
        },
      
    },
    computed:{
        generateCode:function(){
            const nameInitial=this.serviceDetails.ItemName.charAt(0).toUpperCase();
            const typeInitial=this.serviceDetails.ItemType.charAt(0).toUpperCase();
            return typeInitial+nameInitial+this.count;
        }

    }
  }
</script>