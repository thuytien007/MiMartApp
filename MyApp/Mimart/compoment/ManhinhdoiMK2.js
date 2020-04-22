
import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput} from 'react-native';



export default function Mk2({navigation}) {
    return (
      <View style={styles.all}>
         
         <View style = {styles.top}>
            <Text style={styles.textnote}>Để xác nhận thay đổi, vui lòng điền mã xác minh được gửi đến số ********12.</Text>
            <TextInput style = {styles.boderinput} 
                placeholder='Mã xác minh'  
            >
               
           </TextInput>

           <TouchableOpacity style = {styles.bodergl}>
                <Text style={styles.textxm}>Gửi lại</Text>
           </TouchableOpacity>

           <TouchableOpacity onPress={() => navigation.navigate('Mk3')}>
            <View style = {styles.boderxm}>
                <Text style = {styles.textxm}>Xác minh</Text>                    
            </View>
         </TouchableOpacity>
           
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
    marginTop:15
    },
  
  
    textnote: {
      marginLeft:7,
      fontSize: 13
    },

  
    boderinput:{
      borderWidth:1,
      width:370,
      height:50,
      borderColor:'#00D2AD',
      marginLeft:20,
      marginTop:15,
      borderRadius:18,
      paddingHorizontal:20,
      fontSize:11
    },

    bodergl:{
        marginBottom:-69,
        width:160,
        height:50,
        backgroundColor: '#00D2AD',
        marginLeft:20,
        marginTop:20,
        borderRadius:14,
      },

    boderxm:{
      width:160,
      height:50,
      backgroundColor: '#00D2AD',
      marginLeft:220,
      marginTop:20,
      borderRadius:14,
    },
  
    textxm: {
      textAlign:'center',
      width:120,
      height:50,
      marginTop:10,
      marginLeft:20,
      fontSize: 17,
      color:'#ffffff'
    }
  });