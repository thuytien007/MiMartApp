import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput, ScrollView} from 'react-native';
import anhsearch from '../assets/search.png';
import anhpho from '../assets/pho.png';
import anhhutieu from '../assets/hutieu.png';
import anhbunbo from '../assets/bunboHue.png';
import anhmiquang from '../assets/miquang.png';

 export default function CM({navigation}) {
   return (
     <View style={styles.all}>
      
      <TextInput style = {styles.bodersearch} placeholder=' Tìm kiếm'   >
       </TextInput>
       <Image style={styles.imgsearch} source = {anhsearch} />
    

      <ScrollView> 
        
        <View style = {styles.boder}>
         
          <TouchableOpacity style = {styles.bodermon} >
            <Image style={styles.imgpho} source = {anhpho} />
             <Text style={styles.text}>Phở bò</Text>
             <Text style={styles.text1}>Tác giả:...</Text>
             <Text style={styles.text2}>Nguyên liệu:...</Text>
             <Text style={styles.text3}>...</Text>
          </TouchableOpacity>

          <TouchableOpacity style = {styles.bodermon} >
            <Image style={styles.imgpho} source = {anhbunbo} />
             <Text style={styles.text}>Bún bò huế</Text>
             <Text style={styles.text1}>Tác giả:...</Text>
             <Text style={styles.text2}>Nguyên liệu:...</Text>
             <Text style={styles.text3}>...</Text>
          </TouchableOpacity>

          <TouchableOpacity style = {styles.bodermon} >
            <Image style={styles.imgpho} source = {anhhutieu} />
             <Text style={styles.text}>Hủ tiếu nam vang</Text>
             <Text style={styles.text1}>Tác giả:...</Text>
             <Text style={styles.text2}>Nguyên liệu:...</Text>
             <Text style={styles.text3}>...</Text>
          </TouchableOpacity>

          <TouchableOpacity style = {styles.bodermon} >
            <Image style={styles.imgpho} source = {anhmiquang} />
             <Text style={styles.text}>Mì quảng</Text>
             <Text style={styles.text1}>Tác giả:...</Text>
             <Text style={styles.text2}>Nguyên liệu:...</Text>
             <Text style={styles.text3}>...</Text>
          </TouchableOpacity>

          <TouchableOpacity style = {styles.bodermon} >
            <Image style={styles.imgpho} source = {anhpho} />
             <Text style={styles.text}>Phở bò</Text>
             <Text style={styles.text1}>Tác giả:...</Text>
             <Text style={styles.text2}>Nguyên liệu:...</Text>
             <Text style={styles.text3}>...</Text>
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


  bodersearch:{
    borderWidth:1,
    width:340,
    height:50,
    borderColor:'#00D2AD',
    marginTop:10,
    marginLeft:10,
    paddingHorizontal:20,
    borderRadius:14,
  },

  imgsearch: {
    width: 32,
    height:32,
    marginLeft:370,
    marginTop: -35
  },

  boder:{
    borderWidth: 1,
    width:412,
    height:700,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    marginTop:40, 
    marginLeft:0, 
  },

  bodermon:{
    width:370,
    height:100,
    backgroundColor:'#87cefa',
    marginTop:20, 
    
  },

  imgpho: {
    width: 100,
    height:100,

  },

  text: {
    marginLeft:120,
    marginTop:-95,
    fontSize: 18
  },

  text1: {
    marginLeft:120,
    marginTop:7,
    fontSize: 12
  },

  text2: {
    marginLeft:120,
    marginTop:10,
    fontSize: 12
  },

  text3: {
    marginLeft:120,
    marginTop:2,
    fontSize: 12
  },


});
