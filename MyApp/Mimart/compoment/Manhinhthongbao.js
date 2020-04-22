import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput, ScrollView} from 'react-native';
import anhvin from '../assets/vin.png';
import anhbhx from '../assets/bhx.png';
import anhcoop from '../assets/coop.png';
import anhsale1 from '../assets/sale.png';
import anhsale2 from '../assets/sale1.png';
import anhsale3 from '../assets/sale2.png';
import anhsale4 from '../assets/mien.png';
import anhsale5 from '../assets/caphe.png';
import anhsp from '../assets/newproduct.png';
import anhca from '../assets/cahoi.png';
import anhga from '../assets/ga.png';
import anhhethong from '../assets/system.png';
import anhcapnhat from '../assets/update.png';

 export default function TB({navigation}) {
   return (
     <View style={styles.all}>
      
      <ScrollView> 
        
          <View >
              <Image style={styles.imgsale} source = {anhsale1} /> 
              <Text style={styles.textkm}  >Khuyến mãi </Text>  

              <ScrollView horizontal={true}>
                <Image style={styles.imgsale1} source = {anhbhx} /> 
                <Image style={styles.imgsale1} source = {anhsale2} /> 
                <Image style={styles.imgsale2} source = {anhsale3} /> 
                <Image style={styles.imgsale1} source = {anhsale4} /> 
                <Image style={styles.imgsale1} source = {anhsale5} /> 
                <Image style={styles.imgsale1} source = {anhsale2} /> 
                <Image style={styles.imgsale1} source = {anhsale3} /> 
              </ScrollView>
            </View>

            <View>
              <Image style={styles.imgsp} source = {anhsp} /> 
              <Text style={styles.textkm}  >Sản phẩm mới </Text>  
              <ScrollView horizontal={true}>
                <TouchableOpacity style = {styles.boder} >
                    <Image style={styles.imgca} source = {anhca} />
                    <Text style={styles.text}>Cá hồi</Text>
                    <Text style={styles.text1}>200.000 VNĐ</Text>
                 </TouchableOpacity>
                
                 <TouchableOpacity style = {styles.boder} >
                    <Image style={styles.imgca} source = {anhga} />
                    <Text style={styles.text}>Đùi gà</Text>
                    <Text style={styles.text1}>100.000 VNĐ</Text>
                 </TouchableOpacity>

              </ScrollView>
            </View>

            <View>
              <Image style={styles.imgsp} source = {anhhethong} /> 
              <Text style={styles.textkm}  >Hệ thống </Text> 
              <TouchableOpacity style = {styles.boder} >
                    <Text style={styles.textht}>MiMart đã có phiên bản mới cải tiến hơn về ....</Text>
                    <Text style={styles.textht}>MiMart sẽ bảo trì hệ thống vào ngày dd/mm/yyyy</Text>
                    <Text style={styles.textht}>MiMart sẽ mở rộng thêm các đơn vị vận chuyển ...</Text>
                 </TouchableOpacity>
            </View>
              
            <View>
              <Image style={styles.imgsp} source = {anhcapnhat} /> 
              <Text style={styles.textkm}  >Cập nhật đơn hàng </Text> 
              <TouchableOpacity style = {styles.boder} >
              <Image style={styles.imgca1} source = {anhca} />
                    <Text style={styles.textdh}>Đã giao hàng thành công</Text>
                    <Text style={styles.textdh1}>Đơn hàng có mã đơn hàng DHN04 đã giao hàng thành công vào ngày dd/mm/yy</Text>
                 </TouchableOpacity>
            </View>
         

       
        </ScrollView>
     </View>
   );
 }

const styles = StyleSheet.create({
  all: {
    width:410,
    height:680
  },

  top: {
    alignItems: 'flex-start',
    width: 410,
    height: 120,
    backgroundColor: '#00D2AD',
    marginBottom: 15,
  },

  imgsale: {
    width: 32,
    height:32,
    marginLeft:10,
    marginTop: 10
  },

  textkm: {
    marginTop:-25,
    marginLeft:60,
    fontSize: 13
  },

  imgsale1: {
    width: 72,
    height:72,
    marginLeft:20,
    marginTop: 20
  },

  imgsale2: {
    width: 100,
    height:72,
    marginLeft:20,
    marginTop: 20
  },

  imgsp: {
    width: 32,
    height:32,
    marginLeft:10,
    marginTop: 40
  },
  
  boder:{
    width:420,
    height:100,
    backgroundColor:'#87cefa',
    marginTop:20, 
    
  },

  text: {
    marginLeft:220,
    marginTop:-75,
    fontSize: 18
  },

  text1: {
    marginLeft:200,
    marginTop:7,
    fontSize: 18
  },

  imgca: {
    width: 150,
    height:100,
   
  },

  textht: {
    marginTop:10,
    marginLeft:20,
    fontSize: 15
  },
  
  imgca1: {
    width: 100,
    height:80,
   
  },

  textdh: {
    marginTop:-70,
    marginLeft:110,
    fontSize: 13,
    fontWeight: 'bold'
  },

  textdh1: {
    marginTop:10,
    marginLeft:110,
    fontSize: 13,
  },
});
