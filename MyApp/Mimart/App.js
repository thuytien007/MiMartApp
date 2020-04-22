import React from 'react';
import { StyleSheet, Text, View, Button, TouchableOpacity} from 'react-native';
import Mk1 from './compoment/ManhinhdoiMK1';
import Mk2 from './compoment/ManhinhdoiMK2';
import Mk3 from './compoment/ManhinhdoiMK3';
import Ls1 from './compoment/Manhinhlichsu1';
import Ls2 from './compoment/Manhinhlichsu2';
import TT from './compoment/Manhinhchinhsuathongtin';
import DK from './compoment/Manhinhdangki';
import CM from './compoment/Manhinhchonmontunutloc';
import TB from './compoment/Manhinhthongbao';
import 'react-native-gesture-handler';
import { NavigationContainer } from '@react-navigation/native';
import {createStackNavigator } from '@react-navigation/stack';
import {AntDesign, Ionicons} from '@expo/vector-icons';


 export default function App() {
   const Stack = createStackNavigator();
   return (
      <NavigationContainer>
       <Stack.Navigator>

         <Stack.Screen name="Mk1" component={Mk1}
          options ={{
            title: "Tài khoản",
            headerStyle: {
              backgroundColor: '#00D2AD',
            },
            headerRight: () => (
              <View >
                    <TouchableOpacity style={{marginLeft:50, marginBottom:25}} onPress={() => alert('Đến giỏ hàng')}>
                       <AntDesign name="shoppingcart"  size={28}  >  </AntDesign> 
                    </TouchableOpacity>
                   
                    <TouchableOpacity style={{marginLeft:100,  marginTop:-60}} onPress={() => alert('Đến thông báo')}>
                      <Ionicons name="ios-notifications-outline"  size={32} >  </Ionicons>  
                    </TouchableOpacity>
               
              </View >
            ),
            
           }
          }
          />


       <Stack.Screen name="Mk2" component={Mk2} 
         options ={{
          title: "Xác minh",
          headerStyle: {
            backgroundColor: '#00D2AD',
          },
         }
        }
         />


        <Stack.Screen name="Mk3" component={Mk3}
          options ={{
            title: "Tài khoản",
            headerStyle: {
              backgroundColor: '#00D2AD',
            }  
          }
          }
          />     

          {/* <Stack.Screen name="Ls1" component={Ls1}
          options ={{
            title: "Lịch sử mua hàng",
            headerStyle: {
              backgroundColor: '#00D2AD',
            },
            headerRight: () => (
              <View >
                    <TouchableOpacity style={{marginLeft:50, marginBottom:25}} onPress={() => alert('Đến giỏ hàng')}>
                       <AntDesign name="shoppingcart"  size={28}  >  </AntDesign> 
                    </TouchableOpacity>
                   
                    <TouchableOpacity style={{marginLeft:100,  marginTop:-60}} onPress={() => alert('Đến thông báo')}>
                      <Ionicons name="ios-notifications-outline"  size={32} >  </Ionicons>  
                    </TouchableOpacity>
               
              </View >
            ),
          }
          }
          />

        <Stack.Screen name="Ls2" component={Ls2}
          options ={{
            title: "Chi tiết đơn hàng",
            headerStyle: {
              backgroundColor: '#00D2AD',
            },
            headerRight: () => (
              <View >
                    <TouchableOpacity style={{marginLeft:50, marginBottom:25}} onPress={() => alert('Đến giỏ hàng')}>
                       <AntDesign name="shoppingcart"  size={28}  >  </AntDesign> 
                    </TouchableOpacity>
                   
                    <TouchableOpacity style={{marginLeft:100,  marginTop:-60}} onPress={() => alert('Đến thông báo')}>
                      <Ionicons name="ios-notifications-outline"  size={32} >  </Ionicons>  
                    </TouchableOpacity>
               
              </View >
            ),  
          }
          }
          />  

         <Stack.Screen name="TT" component={TT}
          options ={{
            title: "Chỉnh sửa thông tin",
            headerStyle: {
              backgroundColor: '#00D2AD', 
            },
            headerRight: () => (
              <Button 
                 onPress={() => alert('Đã lưu thông tin')}
                  title="Lưu"
                 color="#00D2AD"
              />
            )
           }
           }
          
          /> 

        <Stack.Screen name="DK" component={DK}
          options ={{
            title: " ",
            headerStyle: {
              backgroundColor: '#00D2AD',
            }
           }
          }
          />  

         <Stack.Screen name="CM" component={CM}
          options ={{
            title: "Món nước",
            headerStyle: {
              backgroundColor: '#00D2AD',
            }
           }
          }
          />  

        <Stack.Screen name="TB" component={TB}
          options ={{
            title: "Thông báo",
            headerStyle: {
              backgroundColor: '#00D2AD',
            },
            headerRight: () => (
              <TouchableOpacity onPress={() => alert('Đã lưu thông tin')}
                  color="#00D2AD">
                    <View style={{marginLeft:50, marginBottom:25}}>
                       <AntDesign name="shoppingcart"  size={28}  >  </AntDesign> 
                    </View>
                   
                    <View style={{marginLeft:100,  marginTop:-60}}>
                      <Ionicons name="ios-notifications-outline"  size={32} >  </Ionicons>  
                    </View>
               
              </TouchableOpacity>
          ),  
          }
          } */}
    
       </Stack.Navigator>
     </NavigationContainer>

   );
} 



const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});





  
 
    
 

  

