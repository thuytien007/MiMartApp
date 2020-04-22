import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput, Button} from 'react-native';
import anhacc from '../assets/account.png';
import { color } from 'react-native-reanimated';


 export default function TT({navigation}) {
    return (
    <View style={styles.all}>
       <View style={styles.top}>
         {/* <MaterialCommunityIcons name="account-circle-outline"  size={54}  marginLeft= '180' marginTop='30'>  </MaterialCommunityIcons>  */}
          <Image style={styles.imgacc} source = {anhacc} /> 
         <Text style={styles.textname}>Chạm để thay đổi</Text>
         
       </View>

       <View>
          
          <TextInput style = {styles.boderinput} placeholder='ABC'   >
          </TextInput>

          <TextInput style = {styles.boderinput} placeholder='Nam'   >
          </TextInput>

          <TextInput style = {styles.boderinput} placeholder='1234****56'   >
          </TextInput>

          <TextInput style = {styles.boderinput} placeholder='01/01/1999'   >
          </TextInput>
          
          <TextInput style = {styles.boderinput} placeholder='A/B/C xyz'   >
          </TextInput>
       
          
       </View>

    </View>
  );
}



const styles = StyleSheet.create({
  all: {
    width:410,
    height:900
  },

  top: {
    alignItems: 'flex-start',
    width: 410,
    height: 170,
    backgroundColor: '#a9a9a9',
    marginBottom: 15,
   
  },

  imgacc: {
    width: 50,
    height:50,
    marginLeft:180,
    marginTop:30
  },

  textname: {
    marginLeft:145,
    marginTop:50,
    fontSize: 15
  },

  boderinput:{
    borderWidth:1,
    width:450,
    height:50,
    borderColor:'#00D2AD',
    marginTop:10,
    paddingHorizontal:20,
  },
  
  textxmm: {
    marginTop:35,
    marginLeft:15,
    fontSize: 11
  },

});