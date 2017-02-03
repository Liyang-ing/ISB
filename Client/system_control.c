#include <reg52.h>
#include <stdio.h>
#include <stdlib.h>
#define delay_time 150
#define wda 0xa0
#define rda 0xa1
sbit  SCL= P0^0;
sbit  SDA= P0^1;
sbit  rel0= P0^2;
sbit  rel1= P0^3;
sbit  rel2= P0^4;
sbit  rel3= P0^5;
sbit  ledd= P0^6;
sbit  rr= P0^3;
sbit  work_o = P1^0;
sbit  work   = P1^1;
sbit  work1  = P1^2;
sbit  work2  = P1^3;
sbit  work3  = P1^4;
sbit  chup   = P1^5;
int i,add=40,num=0,c=4;
char  c0,c1,c2,c3,c_tem;
char a[]={"0953650579x"};  //目前 
char b[]={"abcdefghijx"};  //儲存 
char decimal[10]={'0','1','2','3','4','5','6','7','8','9'};
char str[]={"atd<0000000000>;"};
void delay(int d)
{
int i, j;
 for(i=0; i<d; i++)
    for(j=0; j<100; j++)  ;
}
led_work()
{
	ledd=0;
	delay(100);
	ledd=1;
	delay(100);
}
/*----------RS-232控制參數------------*/
Init_rs232()
{ 	
	PCON=0X80;
	SCON=0x50; 
	TMOD=0x20; 
	TH1=0xFF;   //因為鮑率是115200所以是 0xFF ，石英震盪器是22.184M 
	TR1=1; 
	TI=1; 
}
tx_char(unsigned char c)
{
	while(1)
	 if(TI)
	 	 break;
	TI=0;
	SBUF=c;
}
tx_str(char *str)
{
	do
	{
	 tx_char(*str++);

	}while(*str!='\0');
}

char rx_char()
{
	while(1) 
		if(RI) 
			break;
	RI=0;
	return SBUF;
}		
/*---------------------------------*/
/*********************DATASHEET要求********************/ 
void Start()
{
	SDA=1;
	SCL=1;
	SDA=0;
	SCL=0;
}
void Stop()
{
	SCL=0;
	SDA=0;
	SCL=1;
	SDA=1;
}
void NoAck ()
{
	SDA=1;
	SCL=1;
	SCL=0;
}
bit TestAck ()
{
	bit ErrorBit;
	SDA=1;
	SCL=1;
	ErrorBit=SDA;
	SCL=0;
	return(ErrorBit);
}	 
/*********************寫入DATA*******************/ 
void Write8bit(char input)
{
	char temp;
	for(temp=8;temp!=0;temp--)
	{
		SDA=(bit)(input&0x80);
		SCL=1;
		SCL=0;
		input=input<<1;
	}
}
void Write24c08(char ch, char address)
{
	EA=0;
	Start();
	Write8bit(wda);
	TestAck ();
	Write8bit(address);
	TestAck ();
	Write8bit(ch);
	TestAck ();
	Stop();
	delay(20);
	EA=1;
}
void Write24c08_uint(int dat,char address)
{
	char hi8,lo8;
	hi8=dat/256;
	lo8=dat%256;
	Write24c08(hi8,address);
	delay(20);
	Write24c08(lo8,address+add);
}	  
/*********************讀取DATA********************/

char Read8bit()
{
	char temp,rbyte=0;
	for(temp=8;temp!=0;temp--)
	{
		SCL=1;
		rbyte=rbyte<<1;
		rbyte=rbyte|((char)(SDA));
		SCL=0; 
	}
	return (rbyte);
}
char Read24c08(char address)
{
	char ch;
	Start();
	Write8bit(wda);
	TestAck();
	Write8bit(address);
	TestAck();
	Start();
	Write8bit(rda);
	TestAck();
	ch=Read8bit();
	NoAck();
	Stop();
	return(ch);
}
int Read24c08_uint(char address)
{
	int dat;
	char hi8,lo8;
	hi8=Read24c08(address);
	lo8=Read24c08(address+add);//
	dat=(256*hi8)+lo8;
	return (dat);
}
void s_send_computer()
{
	if(c1=='s')
	{
			for(i=0;i<11;i++)   //把暫存區的資料送到電腦 
			{
				printf("%c",a[i]);
			}
			c2=rx_char();
			if(c2=='b')  //把電腦的資料傳到記憶體 
			{
				printf("back_in\n");
				while(1)
				{
					a[num]=rx_char();
					Write24c08_uint(a[num],num);//傳到記憶體 
					delay(10);
					if(num==10)
					{
						num=0;
						break;
					}	
					num++;
				}
				printf("back\n");	
			}	
	}
}		 
number()
{
	int c=4;
	while(1)
 	{
		 if(work==0)
			if(work1==0)
				if(work2==0)
					if(work3==1)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[1];
						}
					}
		 if(work==0)
			if(work1==0)
				if(work2==1)
					if(work3==0)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[2];
						}
					}			
		 if(work==0)
			if(work1==0)
				if(work2==1)
					if(work3==1)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[3];
						}
					}
		 if(work==0)
			if(work1==1)
				if(work2==0)
					if(work3==0)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[4];
						}
					}
			/****************/
		if(work==0)
			if(work1==1)
				if(work2==0)
					if(work3==1)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[5];
						}
					}
		 if(work==0)
			if(work1==1)
				if(work2==1)
					if(work3==0)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[6];
						}
					}
		 if(work==0)
			if(work1==1)
				if(work2==1)
					if(work3==1)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[7];
						}
					}		
		 if(work==1)
			if(work1==0)
				if(work2==0)
					if(work3==0)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[8];
						}
					}
		 if(work==1)
			if(work1==0)
				if(work2==0)
					if(work3==1)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[9];
						}
					}
		/*******************/		
		if(work==1)
			if(work1==0)
				if(work2==1)
					if(work3==0)
					{
						if(work_o==1)
						{
							led_work();
							delay(delay_time);
							str[c++]=decimal[0];
						}
					}	
		if(c==14)
		{	
			c=4;
			break;
		}				
    }
    
	for(i=4;i<14;i++)
	{
		a[i-4]=str[i];
	}
	if(a[1]!='9')
    {
		rel0=0;
		for(i=0;i<6;i++)
		{
			rel0 =~rel0;
			delay(1000);
		}
	}
}
read_word()          //讀!!!!!!!!! 
{
	for(i=0;i<11;i++)
	{
		c_tem=Read24c08_uint(i);
		delay(10);
		b[i]=c_tem;	
	}
}
call_o()
{
	if(b[10]=='f' || b[10]=='x')
	{
		puts(str);
	}
	if(b[10]=='c')
	{
		for(i=0;i<5;i++)
		{
			rel2 =~rel2;
			delay(5000);
		}
	}
	if(b[10]=='n')
	{
		for(i=0;i<5;i++)
		{
			rel3 =~rel3;
			delay(5000);
		}
	}
}

main() 
{  
	Init_rs232();
	printf("initial_OK\n");
	read_word();   //一開始就把資料寫回微控制器 
	led_work();
	number();
	call_o();
 	while(1) 
 	{ 	
		c1=rx_char();
		switch(c1)
		{
			case 's':  //電腦使用時 
			{
				s_send_computer();
				break;
			}	
			case 'm':  //電腦使用時 
			{
				printf("\nb=");
				for(i=0;i<11;i++)
				{
					printf("%c",b[i]);
				}
				printf("\na=");
				for(i=0;i<11;i++)
				{
					printf("%c",a[i]);
				}
				break;
			}  
			default	:
			{
				if(chup==0)
				{
					printf("\nOK");
					puts("at+chup");
				}
			}		
		}  
 	} 
}

