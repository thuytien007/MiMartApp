import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput, ScrollView} from 'react-native';
import anhvin from '../assets/vin.png';
import anhgao from '../assets/gao.png';
import anhcaphe from '../assets/caphe.png';
import anhbhx from '../assets/bhx.png';
import anhpho from '../assets/pho.png';
import anhmien from '../assets/mien.png';
import anhcoop from '../assets/coop.png';
import { AuthSession } from 'expo';

 export default function Ls2() {
   return (
     <View style={styles.all}>
    
          <View style = {styles.bodermd1}  >
              <Text style={styles.textxmm1}  >Mã đơn hàng:
                <Text style={{fontSize:9, fontWeight: "bold"}}> DHN04
                </Text> 
                </Text>  
              <Text style={styles.textxmm2} > 19/02/2020</Text>  
          </View>

       <ScrollView>
          <View>
             <View style = {styles.boderchitiet1} >
                <Image style={styles.imgvin} source = {anhvin} />
                <Text style={styles.texttench1}  > Vinmart </Text>  
                <View style ={styles.linech}> 
               </View>
                <Image style={styles.imggao} source = {anhgao} />
                <Text style={styles.sp1}  > Gạo thơm thượng hạng Neptune túi 5kg </Text>  
                <Text style={styles.giasp1}  > 138.000đ </Text>  
                <View style ={styles.line}> 
              </View>
                <Image style={styles.imgcaphe} source = {anhcaphe} />
                <Text style={styles.sp1}  > Cà phê sữa G7 3 in 1 288g </Text>  
                <Text style={styles.giasp1}  > 48.000đ </Text>  
              </View>
          </View>

          <View>
              <View style = {styles.boderchitiet1} >
                <Image style={styles.imgbhx} source = {anhbhx} />
                <Text style={styles.texttench1}  > Bách hóa xanh </Text>  
                <View style ={styles.linech}> 
                </View>
                <Image style={styles.imgpho} source = {anhpho} />
                <Text style={styles.sp2}  >Phở hộp Chinsu </Text>  
                <Text style={styles.giasp1}  > 11.000đ </Text>  
                <View style ={styles.line}> 
                </View>
                <Image style={styles.imgmien} source = {anhmien} />
                <Text style={styles.sp2}  > Miến phú hương  </Text>  
                <Text style={styles.giasp1}  > 9.000đ </Text>  
            </View>
          </View>
          
          <View>
              <View style = {styles.boderchitiet1} >
                <Image style={styles.imgcoop} source = {anhcoop} />
                <Text style={styles.texttench1}  > CoopMart </Text>  
                <View style ={styles.linech}> 
                </View>
                <Image style={styles.imgpho} source = {anhpho} />
                <Text style={styles.sp2}  >Phở hộp Chinsu </Text>  
                <Text style={styles.giasp1}  > 11.000đ </Text>  
                <View style ={styles.line}> 
                </View>
                <Image style={styles.imgmien} source = {anhmien} />
                <Text style={styles.sp2}  > Miến phú hương  </Text>  
                <Text style={styles.giasp1}  > 9.000đ </Text>  
              </View>
           </View>

           <View>
             <View style = {styles.boderchitiet1} >
                <Image style={styles.imgvin} source = {anhvin} />
                <Text style={styles.texttench1}  > Vinmart </Text>  
                <View style ={styles.linech}> 
               </View>
                <Image style={styles.imggao} source = {anhgao} />
                <Text style={styles.sp1}  > Gạo thơm thượng hạng Neptune túi 5kg </Text>  
                <Text style={styles.giasp1}  > 138.000đ </Text>  
                <View style ={styles.line}> 
              </View>
                <Image style={styles.imgcaphe} source = {anhcaphe} />
                <Text style={styles.sp1}  > Cà phê sữa G7 3 in 1 288g </Text>  
                <Text style={styles.giasp1}  > 48.000đ </Text>  
              </View>
          </View>
          
          
      

        </ScrollView>
     </View>
   );
 }

const styles = StyleSheet.create({
  all: {
    width:410,
    height: 680
  },

  top: {
    alignItems: 'flex-start',
    width: 410,
    height: 120,
    backgroundColor: '#00D2AD',
    marginBottom: 15,
  },

  imgback: {
    width: 20,
    height:20,
    marginLeft:10,
    marginTop: 85
  },

  textback: {
    marginLeft:40,
    marginTop:-26,
    fontSize: 13
  },

  
  imgtb: {
    width: 28,
    height:28,
    marginLeft:360,
    marginTop: -25
  },

  textxmm1: {
    marginTop:8,
    marginLeft:10,
    fontSize: 13
  },

  textxmm2: {
    marginLeft:270,
    marginTop:-18,
    fontSize: 13
  },

  texttench1: {
    marginLeft:60,
    marginTop:-30,
    fontSize: 11
  },

  imgvin: {
    width: 32,
    height:32,
    marginLeft:10,
    marginTop: 8
  },

  imggao: {
    width: 64,
    height:80,
    marginLeft: 1,
    marginTop: 10
  },

  sp1: {
    marginLeft:70,
    marginTop:-70,
    fontSize: 13
  },

  giasp1: {
    marginLeft:280,
    marginTop:20,
    fontSize: 13
  },

  linech:{
    borderWidth: 0.5,
    borderColor:'#000000',
    borderWidth: 0.5,
    marginTop: 18
  },

  line:{
    borderWidth: 1,
    borderColor:'#dcdcdc',
    margin:12,
  },


  imgcaphe: {
    width: 64,
    height:90,
    marginLeft: 1,
    marginTop: -10
  },

 

  bodermd1:{
    borderWidth: 1,
    width:500,
    height:40,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    marginTop:10,  
  },

  bodertench1:{
    borderWidth: 1,
    width:500,
    height:50,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    
  },
  

  imgbhx: {
    width: 32,
    height:32,
    marginLeft:10,
    marginTop: 8
  },
  
  imgpho: {
    width: 64,
    height:64,
    marginLeft: 1,
    marginTop: 10
  },

  imgcoop: {
    width: 32,
    height:32,
    marginLeft:10,
    marginTop: 8
  },
  imgmien: {
    width: 64,
    height:54,
    marginLeft: 1,
    marginTop: 10
  },
  
  sp2: {
    marginLeft:80,
    marginTop:-60,
    fontSize: 13
  },


  boderchitiet1:{
    borderWidth: 1,
    height:260,
    width:420,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    borderRadius: 35,
    marginTop:10
  },
  



});
