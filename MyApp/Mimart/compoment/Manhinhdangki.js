
import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput, Button, Alert} from 'react-native';
import anhlogo from '../assets/logo4.png';


 export default function DK({navigation}) {
    return (
    <View style={styles.all}>
       <View style={styles.top}>
       <Text style={styles.textnamelogo}>MIMART</Text>
       
         <Image style={styles.imglogo} source = {anhlogo} />
         <Text style={styles.textname}>Yêu là phải nói, đói là phải đến MiMart</Text>
         
       </View>

       <View>
          
       <TextInput style = {styles.boderinput} placeholder='Số điện thoại'   >
       </TextInput>
      

       <TextInput style = {styles.boderinput} placeholder='Tên'   >
       </TextInput>
    

       <TextInput style = {styles.boderinput} placeholder='Ngày sinh'   >
       </TextInput>
  

       <TextInput style = {styles.boderinput} placeholder='Giới tính'   >
       </TextInput>
       
       <TextInput style = {styles.boderinput} placeholder='Mật khẩu' secureTextEntry  >
       </TextInput>
  

       <TextInput style = {styles.boderinput} placeholder='Nhập lại mật khẩu' secureTextEntry  >
       </TextInput>

       <TouchableOpacity style = {styles.boderdk} onPress={() =>{
            alert('Bạn đã đăng kí thành công!');
               }}  >
           <Text style={styles.textdk}>Đăng ký</Text>
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
    alignItems: 'flex-start',
    width: 420,
    height: 210,
    backgroundColor: '#00D2AD',
    marginBottom: 15,
   
  },

  textnamelogo: {
    marginLeft:170,
    marginTop:10,
    fontSize: 24,
    color: '#ffffff'
  },

  imglogo: {
    width: 84,
    height: 84,
    marginLeft:170,
    marginTop:18
  },

  textname: {
    marginLeft:90,
    marginTop:20,
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

  textdk: {
    width:120,
    height:50,
    marginTop:11,
    marginLeft:45,
    fontSize: 19,
    fontWeight: "bold"
  },

  boderdk:{
    marginBottom:20,
    width:160,
    height:50,
    backgroundColor: '#00D2AD',
    marginLeft:130,
    marginTop:20,
    borderRadius:14,
  },
});