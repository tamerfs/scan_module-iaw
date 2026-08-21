using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Multiecuscan;

// Token: 0x020000BD RID: 189
public class GClass117 : GClass115
{
	// Token: 0x06000633 RID: 1587 RVA: 0x000DEAAC File Offset: 0x000DCCAC
	public GClass117()
	{
		this.method_4();
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x000DEB00 File Offset: 0x000DCD00
	public GClass117(int int_4)
	{
		this.list_0 = new List<MapRowData>();
		for (int i = 0; i < this.int_3 + 1; i++)
		{
			MapRowData mapRowData = new MapRowData();
			for (int j = 0; j < this.int_2 + 1; j++)
			{
				if (i == 0)
				{
					mapRowData.SetCol(j, (j == 0) ? "" : "-0.0000");
				}
				else
				{
					mapRowData.SetCol(j, (j == 0) ? "-0.0000" : "");
				}
			}
			this.list_0.Add(mapRowData);
		}
		this.int_0 = int_4;
		this.method_4();
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x000DEBCC File Offset: 0x000DCDCC
	public GClass117(int int_4, int int_5, int int_6)
	{
		this.int_0 = int_4;
		this.int_2 = int_6;
		this.int_3 = int_5;
		this.method_4();
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x000DEC34 File Offset: 0x000DCE34
	private void method_4()
	{
		base.SuspendLayout();
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Paint += this.GClass117_Paint;
		this.BackColor = Color.White;
		this.dgvMapData = new DataGridView();
		this.cbXAxisParameter = new ComboBox();
		this.cbYAxisParameter = new ComboBox();
		this.cbYAxisParameter_1 = new ComboBox();
		this.label1 = new Label();
		this.label2 = new Label();
		this.label3 = new Label();
		((ISupportInitialize)this.dgvMapData).BeginInit();
		this.dgvMapData.AllowUserToAddRows = false;
		this.dgvMapData.AllowUserToDeleteRows = false;
		this.dgvMapData.AllowUserToResizeRows = false;
		this.dgvMapData.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dgvMapData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvMapData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		this.dgvMapData.BackgroundColor = Color.White;
		this.dgvMapData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dgvMapData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvMapData.ColumnHeadersVisible = false;
		for (int i = 0; i < this.int_2 + 1; i++)
		{
			DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn.DataPropertyName = "Col" + i.ToString();
			dataGridViewTextBoxColumn.Name = "col" + i.ToString();
			dataGridViewTextBoxColumn.ReadOnly = true;
			dataGridViewTextBoxColumn.Visible = true;
			if (i == 0)
			{
				dataGridViewTextBoxColumn.CellTemplate.Style.BackColor = Color.Navy;
				dataGridViewTextBoxColumn.CellTemplate.Style.ForeColor = Color.White;
			}
			this.dgvMapData.Columns.Add(dataGridViewTextBoxColumn);
		}
		this.dgvMapData.Location = new Point(2, 2);
		this.dgvMapData.Size = new Size(base.Width - 4, base.Height - 26);
		this.dgvMapData.Name = "dgvMapData";
		this.dgvMapData.ReadOnly = true;
		this.dgvMapData.RowHeadersVisible = false;
		this.dgvMapData.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dgvMapData.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dgvMapData.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dgvMapData.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;
		this.dgvMapData.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dgvMapData.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		this.dgvMapData.RowTemplate.Height = 24;
		this.dgvMapData.ScrollBars = ScrollBars.Both;
		this.dgvMapData.SelectionMode = DataGridViewSelectionMode.CellSelect;
		this.dgvMapData.ShowEditingIcon = false;
		this.dgvMapData.TabIndex = 1;
		this.dgvMapData.RowPrePaint += this.dgvMapData_RowPrePaint;
		this.dgvMapData.Paint += this.dgvMapData_Paint;
		base.Controls.Add(this.dgvMapData);
		this.cbXAxisParameter.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cbXAxisParameter.FlatStyle = FlatStyle.Flat;
		this.cbXAxisParameter.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.cbXAxisParameter.FormattingEnabled = true;
		this.cbXAxisParameter.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.cbXAxisParameter.Location = new Point(32, base.Height - 24);
		this.cbXAxisParameter.Name = "cbXAxisParameter";
		this.cbXAxisParameter.Size = new Size(195, 22);
		this.cbXAxisParameter.BackColor = Color.FromArgb(248, 248, 168);
		this.cbXAxisParameter.TabIndex = 2;
		this.cbXAxisParameter.Tag = "5042";
		this.cbXAxisParameter.SelectedIndexChanged += this.cbXAxisParameter_SelectedIndexChanged;
		base.Controls.Add(this.cbXAxisParameter);
		this.cbYAxisParameter.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cbYAxisParameter.FlatStyle = FlatStyle.Flat;
		this.cbYAxisParameter.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.cbYAxisParameter.FormattingEnabled = true;
		this.cbYAxisParameter.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.cbYAxisParameter.Location = new Point(277, base.Height - 24);
		this.cbYAxisParameter.Name = "cbYAxisParameter";
		this.cbYAxisParameter.Size = new Size(195, 22);
		this.cbYAxisParameter.BackColor = Color.FromArgb(248, 248, 168);
		this.cbYAxisParameter.TabIndex = 2;
		this.cbYAxisParameter.Tag = "5043";
		this.cbYAxisParameter.SelectedIndexChanged += this.cbYAxisParameter_SelectedIndexChanged;
		base.Controls.Add(this.cbYAxisParameter);
		this.cbYAxisParameter_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cbYAxisParameter_1.FlatStyle = FlatStyle.Flat;
		this.cbYAxisParameter_1.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.cbYAxisParameter_1.FormattingEnabled = true;
		this.cbYAxisParameter_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.cbYAxisParameter_1.Location = new Point(525, base.Height - 24);
		this.cbYAxisParameter_1.Name = "cbYAxisParameter";
		this.cbYAxisParameter_1.Size = new Size(195, 22);
		this.cbYAxisParameter_1.BackColor = Color.FromArgb(248, 248, 168);
		this.cbYAxisParameter_1.TabIndex = 2;
		this.cbYAxisParameter_1.Tag = "5044";
		this.cbYAxisParameter_1.SelectedIndexChanged += this.cbYAxisParameter_1_SelectedIndexChanged;
		base.Controls.Add(this.cbYAxisParameter_1);
		this.label1.AutoSize = true;
		this.label1.FlatStyle = FlatStyle.Flat;
		this.label1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label1.ForeColor = Color.Navy;
		this.label1.Location = new Point(2, base.Height - 21);
		this.label1.Name = "label1";
		this.label1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label1.Size = new Size(30, 20);
		this.label1.TabIndex = 10;
		this.label1.Tag = "";
		this.label1.Text = "X:";
		base.Controls.Add(this.label1);
		this.label2.AutoSize = true;
		this.label2.FlatStyle = FlatStyle.Flat;
		this.label2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label2.ForeColor = Color.Navy;
		this.label2.Location = new Point(247, base.Height - 21);
		this.label2.Name = "label2";
		this.label2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label2.Size = new Size(30, 20);
		this.label2.TabIndex = 10;
		this.label2.Tag = "";
		this.label2.Text = "Y:";
		base.Controls.Add(this.label2);
		this.label3.AutoSize = true;
		this.label3.FlatStyle = FlatStyle.Flat;
		this.label3.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label3.ForeColor = Color.Navy;
		this.label3.Location = new Point(495, base.Height - 21);
		this.label3.Name = "label3";
		this.label3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label3.Size = new Size(30, 20);
		this.label3.TabIndex = 10;
		this.label3.Tag = "";
		this.label3.Text = "Z:";
		base.Controls.Add(this.label3);
		GClass105 gclass = GClass126.smethod_0();
		this.string_0 = "";
		if (gclass != null)
		{
			for (int j = 0; j < gclass.list_0.Count; j++)
			{
				this.cbXAxisParameter.Items.Add(gclass.list_0[j]);
				this.cbYAxisParameter.Items.Add(gclass.list_0[j]);
				this.cbYAxisParameter_1.Items.Add(gclass.list_0[j]);
				this.string_0 = this.string_0 + gclass.list_0[j] + "|";
			}
		}
		if (this.cbXAxisParameter.Items.Count > 0)
		{
			this.cbXAxisParameter.SelectedIndex = 0;
			this.cbYAxisParameter.SelectedIndex = 0;
			this.cbYAxisParameter_1.SelectedIndex = 0;
		}
		this.dgvMapData.DataSource = this.list_0;
		((ISupportInitialize)this.dgvMapData).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void ScrollIncrease(bool bool_1)
	{
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void ScrollDescrease(bool bool_1)
	{
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x00004572 File Offset: 0x00002772
	private void method_5(object sender, ScrollEventArgs e)
	{
		this.dgvMapData.Invalidate();
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x000DF5C8 File Offset: 0x000DD7C8
	private void dgvMapData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (e.RowIndex == 0)
		{
			this.dgvMapData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
			this.dgvMapData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
			this.dgvMapData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Navy;
			this.dgvMapData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Navy;
			return;
		}
		this.dgvMapData.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.White;
		this.dgvMapData.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Navy;
		MapRowData mapRowData = (MapRowData)this.dgvMapData.Rows[e.RowIndex].DataBoundItem;
		for (int i = 1; i < this.dgvMapData.Columns.Count; i++)
		{
			int num = (int)mapRowData.GetColStyle(i);
			int num2;
			int num3;
			int num4;
			if (num == 255)
			{
				num2 = 0;
				num3 = 0;
				num4 = 0;
			}
			else
			{
				if (num > 100)
				{
					num -= 110;
				}
				num2 = ((num < 70) ? 0 : ((int)(70f * ((float)num - 60f) / 30f)));
				num4 = ((num > 30) ? 0 : ((int)(70f * (1f - (float)num / 30f))));
				num3 = ((num > 75 || num < 25) ? 0 : ((int)(70f * (1f - Math.Abs((float)num - 50f) / 25f))));
			}
			this.dgvMapData.Rows[e.RowIndex].Cells[i].Style.ForeColor = ((mapRowData.GetColStyle(i) > 100) ? Color.Red : Color.Navy);
			this.dgvMapData.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(255 - num4 - num3, 255 - num2 - num4, 255 - num2 - num3);
		}
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x000DF848 File Offset: 0x000DDA48
	private void method_6()
	{
		for (int i = 0; i < this.int_3 + 1; i++)
		{
			MapRowData mapRowData = this.list_0[i];
			for (int j = 0; j < this.int_2 + 1; j++)
			{
				mapRowData.SetCol(j, "       ");
				mapRowData.SetColStyle(j, byte.MaxValue);
			}
		}
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x000DF8A0 File Offset: 0x000DDAA0
	private void method_7(Graphics graphics_0)
	{
		GClass105 gclass = GClass126.smethod_0();
		string text = "";
		if (gclass != null)
		{
			for (int i = 0; i < gclass.list_0.Count; i++)
			{
				text = text + gclass.list_0[i] + "|";
			}
		}
		if (text != this.string_0)
		{
			string b = GClass127.smethod_48(this.cbXAxisParameter.SelectedItem);
			string b2 = GClass127.smethod_48(this.cbYAxisParameter.SelectedItem);
			string b3 = GClass127.smethod_48(this.cbYAxisParameter_1.SelectedItem);
			this.cbXAxisParameter.Items.Clear();
			this.cbYAxisParameter.Items.Clear();
			this.cbYAxisParameter_1.Items.Clear();
			this.string_0 = "";
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (gclass != null)
			{
				for (int j = 0; j < gclass.list_0.Count; j++)
				{
					this.cbXAxisParameter.Items.Add(gclass.list_0[j]);
					this.cbYAxisParameter.Items.Add(gclass.list_0[j]);
					this.cbYAxisParameter_1.Items.Add(gclass.list_0[j]);
					this.string_0 = this.string_0 + gclass.list_0[j] + "|";
					if (gclass.list_0[j] == b)
					{
						num = j;
					}
					if (gclass.list_0[j] == b2)
					{
						num2 = j;
					}
					if (gclass.list_0[j] == b3)
					{
						num3 = j;
					}
				}
			}
			if (num < this.cbXAxisParameter.Items.Count)
			{
				this.cbXAxisParameter.SelectedIndex = num;
			}
			if (num2 < this.cbYAxisParameter.Items.Count)
			{
				this.cbYAxisParameter.SelectedIndex = num2;
			}
			if (num3 < this.cbYAxisParameter_1.Items.Count)
			{
				this.cbYAxisParameter_1.SelectedIndex = num3;
			}
		}
		if (!GClass126.bool_12 && GClass125.smethod_67() < 2)
		{
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
		}
		else
		{
			graphics_0.SmoothingMode = SmoothingMode.None;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (gclass == null)
		{
			this.method_6();
			this.dgvMapData.Invalidate();
			return;
		}
		if (gclass.list_0.Count == 0)
		{
			this.method_6();
			this.dgvMapData.Invalidate();
			return;
		}
		int selectedIndex = this.cbXAxisParameter.SelectedIndex;
		int selectedIndex2 = this.cbYAxisParameter.SelectedIndex;
		int selectedIndex3 = this.cbYAxisParameter_1.SelectedIndex;
		if (selectedIndex < gclass.list_0.Count && selectedIndex2 < gclass.list_0.Count && selectedIndex3 < gclass.list_0.Count && selectedIndex >= 0 && selectedIndex2 >= 0 && selectedIndex3 >= 0)
		{
			float[] array = new float[this.int_2];
			array[0] = decimal.ToSingle(gclass.list_4[selectedIndex]);
			array[this.int_2 - 1] = decimal.ToSingle(gclass.list_5[selectedIndex]);
			for (int k = 1; k < this.int_2 - 1; k++)
			{
				array[k] = decimal.ToSingle(gclass.list_4[selectedIndex] + (gclass.list_5[selectedIndex] - gclass.list_4[selectedIndex]) / this.int_2 * k);
			}
			float[] array2 = new float[this.int_3];
			array2[0] = decimal.ToSingle(gclass.list_4[selectedIndex2]);
			array2[this.int_3 - 1] = decimal.ToSingle(gclass.list_5[selectedIndex2]);
			for (int l = 1; l < this.int_3 - 1; l++)
			{
				array2[l] = decimal.ToSingle(gclass.list_4[selectedIndex2] + (gclass.list_5[selectedIndex2] - gclass.list_4[selectedIndex2]) / this.int_3 * l);
			}
			string format = "{0:0.000}";
			if (Math.Abs(array[this.int_2 - 1]) >= 10f)
			{
				format = "{0:0.00}";
			}
			if (Math.Abs(array[this.int_2 - 1]) >= 100f)
			{
				format = "{0:0.0}";
			}
			if (Math.Abs(array[this.int_2 - 1]) >= 1000f)
			{
				format = "{0:0}";
			}
			for (int m = 0; m < this.int_2; m++)
			{
				stringBuilder.Append(string.Format(format, array[m]));
				this.list_0[0].SetCol(m + 1, string.Format(format, array[m]));
			}
			format = "{0:0.000}";
			if (Math.Abs(array2[this.int_3 - 1]) >= 10f)
			{
				format = "{0:0.00}";
			}
			if (Math.Abs(array2[this.int_3 - 1]) >= 100f)
			{
				format = "{0:0.0}";
			}
			if (Math.Abs(array2[this.int_3 - 1]) >= 1000f)
			{
				format = "{0:0}";
			}
			for (int n = 0; n < this.int_3; n++)
			{
				stringBuilder.Append(string.Format(format, array2[n]));
				this.list_0[n + 1].SetCol(0, string.Format(format, array2[n]));
			}
			float[] array3 = new float[3];
			float[] array4 = new float[3];
			List<float[]> list = new List<float[]>();
			for (int num4 = 0; num4 < gclass.list_3.Count; num4++)
			{
				array3 = new float[]
				{
					decimal.ToSingle(gclass.list_3[num4].list_1[selectedIndex]),
					decimal.ToSingle(gclass.list_3[num4].list_1[selectedIndex2]),
					decimal.ToSingle(gclass.list_3[num4].list_1[selectedIndex3])
				};
				list.Add(array3);
			}
			for (int num5 = 0; num5 < this.int_2; num5++)
			{
				float num6 = array[num5];
				SortedList<float, float> sortedList = new SortedList<float, float>();
				for (int num7 = 0; num7 < list.Count; num7++)
				{
					array4[0] = array3[0];
					array4[1] = array3[1];
					array4[2] = array3[2];
					array3 = list[num7];
					if (num7 > 0 && array3[0] != array4[0])
					{
						float key = array4[1] + (array3[1] - array4[1]) * (num6 - array4[0]) / (array3[0] - array4[0]);
						float num8 = array4[2] + (array3[2] - array4[2]) * (num6 - array4[0]) / (array3[0] - array4[0]);
						if (num8 >= decimal.ToSingle(gclass.list_4[selectedIndex3]) && num8 <= decimal.ToSingle(gclass.list_5[selectedIndex3]))
						{
							if (sortedList.ContainsKey(key))
							{
								float num9 = sortedList[key];
								if (num8 > num9)
								{
									sortedList[key] = num9;
								}
								sortedList[key] = (num9 + num8) / 2f;
							}
							else
							{
								sortedList.Add(key, num8);
							}
						}
					}
				}
				int num10 = 0;
				IL_A85:
				while (num10 < this.int_3)
				{
					float num11 = array2[num10];
					byte b4 = 0;
					float num12 = 0f;
					float num13 = 0f;
					float num14 = 0f;
					bool flag = false;
					for (int num15 = 0; num15 < sortedList.Count; num15++)
					{
						num12 = num13;
						num13 = sortedList.Keys[num15];
						if (num15 > 0 && num11 >= num12 && num11 <= num13)
						{
							float num16 = sortedList.Values[num15 - 1];
							float num17 = sortedList.Values[num15];
							num14 = num16 + (num17 - num16) * (num11 - num12) / (num13 - num12);
							flag = true;
							IL_827:
							if (!flag && sortedList.Count > 1)
							{
								b4 += 110;
								if (num11 < sortedList.Keys[0])
								{
									num16 = sortedList.Values[0];
									num17 = sortedList.Values[1];
									num14 = num16 + (num17 - num16) * (num11 - num12) / (num13 - num12);
									flag = true;
								}
								else if (num11 > sortedList.Keys[sortedList.Count - 1])
								{
									num16 = sortedList.Values[sortedList.Count - 2];
									num17 = sortedList.Values[sortedList.Count - 1];
									num14 = num16 + (num17 - num16) * (num11 - num12) / (num13 - num12);
									flag = true;
								}
							}
							if (num14 < decimal.ToSingle(gclass.list_4[selectedIndex3]) || num14 > decimal.ToSingle(gclass.list_5[selectedIndex3]))
							{
								flag = false;
							}
							if (!flag)
							{
								b4 = byte.MaxValue;
							}
							else if (num14 < decimal.ToSingle(gclass.list_4[selectedIndex3]))
							{
								b4 = b4;
							}
							else if (num14 <= decimal.ToSingle(gclass.list_5[selectedIndex3]) && !(gclass.list_5[selectedIndex3] == gclass.list_4[selectedIndex3]))
							{
								b4 += (byte)(100m * (((decimal)num14 - gclass.list_4[selectedIndex3]) / (gclass.list_5[selectedIndex3] - gclass.list_4[selectedIndex3])));
							}
							else
							{
								b4 += 100;
							}
							string value = "";
							format = "{0:0.000}";
							if (Math.Abs(num14) >= 10f)
							{
								format = "{0:0.00}";
							}
							if (Math.Abs(num14) >= 100f)
							{
								format = "{0:0.0}";
							}
							if (Math.Abs(num14) >= 1000f)
							{
								format = "{0:0}";
							}
							if (flag)
							{
								value = string.Format(format, num14);
							}
							stringBuilder.Append(value);
							this.list_0[num10 + 1].SetCol(num5 + 1, value);
							this.list_0[num10 + 1].SetColStyle(num5 + 1, b4);
							num10++;
							goto IL_A85;
						}
					}
					goto IL_827;
				}
			}
			if (stringBuilder.ToString() != this.string_1)
			{
				this.string_1 = stringBuilder.ToString();
				this.dgvMapData.Invalidate();
			}
			return;
		}
		this.method_6();
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x00002F0A File Offset: 0x0000110A
	private void cbXAxisParameter_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x00002F0A File Offset: 0x0000110A
	private void cbYAxisParameter_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x00002F0A File Offset: 0x0000110A
	private void cbYAxisParameter_1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x00002F0A File Offset: 0x0000110A
	private void dgvMapData_Paint(object sender, PaintEventArgs e)
	{
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x000E0384 File Offset: 0x000DE584
	private void GClass117_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		this.method_7(graphics);
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x0000457F File Offset: 0x0000277F
	private void method_8(object sender, MouseEventArgs e)
	{
		this.int_1 = e.X;
	}

	// Token: 0x04000579 RID: 1401
	private bool bool_0 = true;

	// Token: 0x0400057A RID: 1402
	private const float float_1 = 60f;

	// Token: 0x0400057B RID: 1403
	private const float float_2 = 20f;

	// Token: 0x0400057C RID: 1404
	private const float float_3 = 4f;

	// Token: 0x0400057D RID: 1405
	private const float float_4 = 4f;

	// Token: 0x0400057E RID: 1406
	private const float float_5 = 40f;

	// Token: 0x0400057F RID: 1407
	private string string_0 = "";

	// Token: 0x04000580 RID: 1408
	private int int_2 = 16;

	// Token: 0x04000581 RID: 1409
	private int int_3 = 16;

	// Token: 0x04000582 RID: 1410
	private List<MapRowData> list_0 = new List<MapRowData>();

	// Token: 0x04000583 RID: 1411
	private string string_1 = "";

	// Token: 0x04000584 RID: 1412
	private DataGridView dgvMapData;

	// Token: 0x04000585 RID: 1413
	private ComboBox cbXAxisParameter;

	// Token: 0x04000586 RID: 1414
	private ComboBox cbYAxisParameter;

	// Token: 0x04000587 RID: 1415
	private ComboBox cbYAxisParameter_1;

	// Token: 0x04000588 RID: 1416
	private Label label1;

	// Token: 0x04000589 RID: 1417
	private Label label2;

	// Token: 0x0400058A RID: 1418
	private Label label3;
}
