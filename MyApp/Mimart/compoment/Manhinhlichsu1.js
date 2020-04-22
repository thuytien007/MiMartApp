import React from 'react';
import { View, Text, StyleSheet, Image,TouchableOpacity, TextInput, ScrollView} from 'react-native';
import anhvin from '../assets/vin.png';
import anhbhx from '../assets/bhx.png';
import anhcoop from '../assets/coop.png';


 export default function Ls1({navigation}) {
   return (
     <View style={styles.all}>
      
      <ScrollView> 
        <TouchableOpacity onPress={() => navigation.navigate('Ls2')}>  
          <View style = {styles.boderinputb1}  >
              <Text style={styles.textxmm1}  >Mã đơn hàng:
                <Text style={{fontSize:9, fontWeight: "bold"}}> DHN04
                </Text> 
                </Text>  
              <Text style={styles.textxmm2} > 22/02/2020</Text>  
          </View>

          <View style = {styles.boderinput1} >
            <Image style={styles.imgvin} source = {anhvin} />
            <Text style={styles.textxmm3}>Vinmart</Text>
            <Text style={styles.textsl}>9</Text>

            <Image style={styles.imgvin} source = {anhcoop} />
            <Text style={styles.textxmm3}>CoopMart</Text>
            <Text style={styles.textsl}>9</Text>

            <Text style={styles.texttt}  >Tổng cộng:
                <Text style={{color:'red'}}>   750.000
                </Text> 
                </Text>  
          </View>
        </TouchableOpacity>

        <View>
          <View style = {styles.boderinputb2}  >
              <Text style={styles.textxmm1}  >Mã đơn hàng:
                <Text style={{fontSize:9, fontWeight: "bold"}}> DHN03
                </Text> 
                </Text>  
              <Text style={styles.textxmm2} > 21/02/2020</Text>  
          </View>

          <View style = {styles.boderinput1} >
            <Image style={styles.imgvin} source = {anhbhx} />
            <Text style={styles.textxmm3}>Bách hóa xanh</Text>
            <Text style={styles.textsl}>7</Text>

            <Image style={styles.imgvin} source = {anhcoop} />
            <Text style={styles.textxmm3}>CoopMart</Text>
            <Text style={styles.textsl}>9</Text>

            <Text style={styles.texttt}  >Tổng cộng:
                <Text style={{color:'red'}}>   700.000
                </Text> 
                </Text>  
          </View>
        </View>

        <View>
          <View style = {styles.boderinputb3}  >
              <Text style={styles.textxmm1}  >Mã đơn hàng:
                <Text style={{fontSize:9, fontWeight: "bold"}}> DHN02
                </Text> 
                </Text>  
              <Text style={styles.textxmm2} > 20/02/2020</Text>  
          </View>

          <View style = {styles.boderinput1} >
            <Image style={styles.imgvin} source = {anhvin} />
            <Text style={styles.textxmm3}>Vinmart</Text>
            <Text style={styles.textsl}>6</Text>

            <Image style={styles.imgvin} source = {anhbhx} />
            <Text style={styles.textxmm3}>Bách hóa xanh</Text>
            <Text style={styles.textsl}>7</Text>

            <Text style={styles.texttt}  >Tổng cộng:
                <Text style={{color:'red'}}>   680.000
                </Text> 
                </Text>  
          </View>
        </View>

        <View>
          <View style = {styles.boderinputb3}  >
              <Text style={styles.textxmm1}  >Mã đơn hàng:
                <Text style={{fontSize:9, fontWeight: "bold"}}> DHN01
                </Text> 
                </Text>  
              <Text style={styles.textxmm2} > 19/02/2020</Text>  
          </View>

          <View style = {styles.boderinput1} >
            <Image style={styles.imgvin} source = {anhcoop} />
            <Text style={styles.textxmm3}>CoopMart</Text>
            <Text style={styles.textsl}>10</Text>

            <Image style={styles.imgvin} source = {anhvin} />
            <Text style={styles.textxmm3}>Vinmart</Text>
            <Text style={styles.textsl}>9</Text>

            <Text style={styles.texttt}  >Tổng cộng:
                <Text style={{color:'red'}}>   800.000
                </Text> 
                </Text>  
          </View>
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

  textxmm3: {
    marginLeft:60,
    marginTop:-30,
    fontSize: 13
  },

  textsl: {
    marginLeft:330,
    marginTop:-30,
    fontSize: 13
  },


  texttt: {
    marginTop:30,
    marginLeft:220,
    fontSize: 13,
    fontWeight: "bold"
  },

  imgvin: {
    width: 32,
    height:32,
    marginLeft:10,
    marginTop: 30
  },

  boderinputb1:{
    borderWidth: 1,
    width:500,
    height:40,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    marginTop:30,  
  },
  
  boderinput1:{
    borderWidth: 1,
    height:180,
    width:500,
    borderColor:'#00D2AD',
    paddingHorizontal:20
  },
 
  boderinputb2:{
    borderWidth: 1,
    width:500,
    height:40,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    marginTop:50,  
  },

  boderinputb3:{
    borderWidth: 1,
    width:500,
    height:40,
    borderColor:'#00D2AD',
    paddingHorizontal:20,
    marginTop:50,  
  },
});
